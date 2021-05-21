using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Investidor.Models.EBooks
{
    public class FiltroEBooksModel : PagingParameters
    {
        public int? Id { get; set; }

        public string Nome { get; set; }

        public ETipoOrdenacaoEBook? Ordenacao { get; set; }
    }
}
