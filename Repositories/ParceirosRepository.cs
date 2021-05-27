using API_Investidor.Data;
using API_Investidor.Helpers;
using API_Investidor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Investidor.Repositories
{
    public interface IParceirosRepository : IRootRepository<Parceiro>
    {
        PagedResult<Parceiro> GetParceiros(PagingParameters model);

        PagedResult<Parceiro> GetParceiro(int idParceiro);
    }

    public class ParceirosRepository : RootRepository<Parceiro>, IParceirosRepository
    {
        public ParceirosRepository(InvestidorContext InvestidorContext) : base(InvestidorContext) { }

        public PagedResult<Parceiro> GetParceiros(PagingParameters model)
        {
            return _InvestidorContext.parceiro
                .OrderBy(c => c.NOMEPARCEIRO)
                .GetPaged(model.PageNumber, model.PageSize);
        }

        public PagedResult<Parceiro> GetParceiro(int idParceiro)
        {
            return _InvestidorContext.parceiro
                .Where(p => p.IDPARCEIRO == idParceiro)
                .GetPaged(1, 1);
        }
    }
}
