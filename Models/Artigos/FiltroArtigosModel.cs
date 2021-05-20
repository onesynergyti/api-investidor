using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Investidor.Models.Artigos
{
    public class FiltroArtigosModel : PagingParameters
    {
        public int? Id { get; set; }

        public string Nome { get; set; }

        public int? IdCategoria { get; set; }
    }
}
