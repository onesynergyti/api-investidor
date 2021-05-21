using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Investidor.Data
{
    public class Parceiro
    {
        public int IDPARCEIRO { get; set; }

        public string NOMEPARCEIRO { get; set; }

        public string BANNER { get; set; }

        public string CNPJ { get; set; }

        public string TELEFONE { get; set; }

        public string EMAIL { get; set; }

        public string SITE { get; set; }

        public string LINK { get; set; }

        public DateTime? DATACADASTRO { get; set; }

        public char? STATUS { get; set; }

        public string RAZAO_SOCIAL { get; set; }

        public string IE { get; set; }

        public string IM { get; set; }

        public string LOGO { get; set; }
    }
}
