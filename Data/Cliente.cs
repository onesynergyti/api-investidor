using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Investidor.Data
{
    public class Cliente
    {
        public int IDCLIENTE { get; set; }

        public int IDHOTMART { get; set; }

        public string NOMECLIENTE { get; set; }

        public string EMAIL { get; set; }

        public string PLANO { get; set; }

        public DateTime? DATACADASTRO { get; set; }

        public char? STATUS { get; set; }

        public string ICONE { get; set; }

        public string TELEFONE { get; set; }
    }
}
