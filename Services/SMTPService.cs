using System;
using API_Investidor.Models.SMTP;
using API_Investidor.Options;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace API_Investidor.Services
{
    public interface ISMTPService
    {
        bool EnviarCodigoEmailAsync(string email, string codigo);
    }

    public class SMTPService : ISMTPService
    {
        private readonly IOptions<EmailOptions> _emailOptions;

        public SMTPService(IOptions<EmailOptions> options)
        {
            _emailOptions = options;
        }

        private MimeMessage CriarMensagem(EmailMessage message)
        {
            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(message.Sender);
            mimeMessage.To.Add(message.Reciever);
            mimeMessage.Subject = message.Subject;
            mimeMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            { Text = message.Content };
            return mimeMessage;
        }

        public bool EnviarCodigoEmailAsync(string email, string codigo)
        {
            try
            {
                EmailMessage message = new EmailMessage();
                message.Sender = new MailboxAddress("Self", _emailOptions.Value.Sender);
                message.Reciever = new MailboxAddress("Self", email);
                message.Subject = _emailOptions.Value.Assunto;
                message.Content = _emailOptions.Value.MensagemCodigo.Replace(_emailOptions.Value.TagCodigo, codigo);
                var mimeMessage = CriarMensagem(message);

                using (SmtpClient smtpClient = new SmtpClient())
                {
                    smtpClient.Connect(_emailOptions.Value.SmtpServer,
                    _emailOptions.Value.Port, true);
                    smtpClient.Authenticate(_emailOptions.Value.UserName,
                    _emailOptions.Value.Password);
                    smtpClient.Send(mimeMessage);
                    smtpClient.Disconnect(true);
                }

                return true;
            }
            catch(Exception erro)
            {                
                return false;
            }
        }
    }
}