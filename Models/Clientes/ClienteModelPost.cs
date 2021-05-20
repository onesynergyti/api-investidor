using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Investidor.Models.Clientes
{
    public class ClienteModelPost
    {
        public int IDHOTMART { get; set; }

        [Required]
        public string NOMECLIENTE { get; set; }

        public string EMAIL { get; set; }

        [Required]
        public string PLANO { get; set; }

        public string ICONE { get; set; }

        public string TELEFONE { get; set; }
    }
}
