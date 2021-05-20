using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Investidor.Models.Chat
{
    public class FiltroChatModel : PagingParameters
    {
        public int? Id { get; set; }

        public int? IdGrupo { get; set; }
    }
}
