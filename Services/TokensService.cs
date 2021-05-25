using API_Investidor.Data;
using API_Investidor.Models.Token;
using API_Investidor.Repositories;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Text;
using System.Threading.Tasks;

namespace API_Investidor.Services
{
    public interface ITokensService
    {
        Task GerarTokenAsync(TokenAskCode dados);
    }

    public class TokensService : RootService, ITokensService
    {
        protected readonly ITokensRepository _repository;
        protected readonly IClientesRepository _clientesRepository;
        protected readonly IZenviaService _zenviaService;
        protected readonly ISMTPService _SMTPService;

        public TokensService(
            IClientesRepository clientesRepository,
            IZenviaService zenviaService, 
            ITokensRepository repository,
            ISMTPService SMTPService,
            IActionContextAccessor actionContextAccessor) : base(actionContextAccessor)
        {
            _clientesRepository = clientesRepository;
            _zenviaService = zenviaService;
            _SMTPService = SMTPService;
            _repository = repository;
        }

        private string RandomToken(int size)
        {
            Random random = new Random();

            var builder = new StringBuilder(size);

            char offset = 'A';
            const int lettersOffset = 26;

            for (var i = 0; i < size; i++)
            {
                var @char = (char)random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return builder.ToString();
        }

        private async Task EnviarEmailOuSMS(string destino, string token)
        {
            if (destino.Contains("@"))
            {
                try
                {
                    _SMTPService.EnviarCodigoEmailAsync(destino, token);
                }
                catch(Exception ex)
                {
                    AddModelError("Erro no envio de e-mail: " + ex.Message);
                }
            }
            else
            {
                var retorno = await _zenviaService.EnviarCodigoSMSAsync(destino, token);
                if (retorno.statusCode != "00")
                    AddModelError("Erro no envio de SMS: " + retorno.detailDescription);
            }
        }

        public async Task GerarTokenAsync(TokenAskCode dados)
        {
            // Verifica se o cliente existe
            var cliente = _clientesRepository.GetClientePorEmaiOuTelefone(dados.Auth);
            if (cliente == null)
            {
                AddModelError("Cliente não localizado.");
                return;
            }

            // Verifica se existe um token válido
            var token = _repository.GetClienteToken(cliente.IDCLIENTE);

            if (token != null)
            {
                token.AUTH = dados.Auth;
                _repository.Update(token);

                await EnviarEmailOuSMS(dados.Auth, token.CODIGO);
                return;
            }

            // Inclui um novo token
            token = new Token
            {
                IDCLIENTE = cliente.IDCLIENTE,
                CODIGO = RandomToken(6),
                AUTH = dados.Auth,
                DATACADASTRO = DateTime.Now,
                DATAEXPIRA = DateTime.Now.AddMinutes(15)
            };
            _repository.Add(token);

            await EnviarEmailOuSMS(dados.Auth, token.AUTH);
        }
    }
}
