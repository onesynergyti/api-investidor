using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Investidor.Models.Clientes
{
    public class ClienteModelPut
    {
        [Required]
        public int IDCLIENTE { get; set; }

        public int IDHOTMART { get; set; }

        [Required]
        public string NOMECLIENTE { get; set; }

        public string EMAIL { get; set; }

        public string PLANO { get; set; }

        public string ICONE { get; set; }

        [Required]
        public char? STATUS { get; set; }

        public string TELEFONE { get; set; }
    }
}
