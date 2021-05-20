using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_Investidor.Data.Entities
{
    public class EBook
    {
        public int IDEBOOK { get; set; }

        public int? IDCLIENTE { get; set; }

        public string TITULO { get; set; }

        public string LINK { get; set; }

        public string MINIATURA { get; set; }

        public int? CLICKS { get; set; } = 0;

        public DateTime? DATACADASTRO { get; set; }

        public char STATUS { get; set; }

        public string REGRA { get; set; }

        [NotMapped]
        public Cliente CLIENTE { get; set; }
    }
}
