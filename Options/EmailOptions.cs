using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Investidor.Options
{
    public class EmailOptions
    {
        public string Sender { get; set; }
             
        public string SmtpServer { get; set; }
        
        public int Port { get; set; }
        
        public string UserName { get; set; }
        
        public string Password { get; set; }

        public string Assunto { get; set; }

        public string MensagemCodigo { get; set; }

        public string TagCodigo { get; set; }
    }
}
