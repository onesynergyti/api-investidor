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
        PagedResult<Grupo> GetGrupos(PagingParameters model, bool permitePrivado);
    }

    public class GruposRepository : RootRepository<Grupo>, IGruposRepository
    {
        public GruposRepository(InvestidorContext InvestidorContext) : base(InvestidorContext) { }

        public PagedResult<Grupo> GetGrupos(PagingParameters model, bool permitePrivado)
        {
            return _InvestidorContext.grupo
                .Where(c => permitePrivado || c.REGRA == REGRA_PUBLICA)
                .OrderBy(c => c.NOMEGRUPO)
                .GetPaged(model.PageNumber, model.PageSize);
        }
    }

}
