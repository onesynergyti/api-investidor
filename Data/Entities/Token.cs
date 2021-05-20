using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Investidor.Data.Entities
{
    public class Token
    {
        public int IDTOKEN { get; set; }

        public int? IDCLIENTE { get; set; }

        public string AUTH { get; set; }

        public string CODIGO { get; set; }

        public DateTime? DATACADASTRO { get; set; }

        public DateTime? DATAEXPIRA { get; set; }
    }
}
