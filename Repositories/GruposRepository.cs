using API_Investidor.Data;
using API_Investidor.Helpers;
using API_Investidor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Investidor.Repositories
{
    public interface IGruposRepository : IRootRepository<Grupo>
    {
        PagedResult<Grupo> GetGrupos(PagingParameters model);
    }

    public class GruposRepository : RootRepository<Grupo>, IGruposRepository
    {
        public GruposRepository(InvestidorContext InvestidorContext) : base(InvestidorContext) { }

        public PagedResult<Grupo> GetGrupos(PagingParameters model)
        {
            return _InvestidorContext.grupo
                .OrderBy(c => c.NOMEGRUPO)
                .GetPaged(model.PageNumber, model.PageSize);
        }
    }

}
