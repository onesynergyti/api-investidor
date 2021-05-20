using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Investidor.Models.Lives
{
    public class FiltroLivesModel : PagingParameters
    {
        public int? Id { get; set; }

        public string Nome { get; set; }
    }
}
