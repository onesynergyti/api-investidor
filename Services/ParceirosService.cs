using API_Investidor.Data;
using API_Investidor.Models;
using API_Investidor.Repositories;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Investidor.Services
{
    public interface IParceirosService
    {
        PagedResult<Parceiro> GetParceiros(PagingParameters model);

        PagedResult<Parceiro> GetParceiro(int idParceiro);
    }

    public class ParceirosService : RootService, IParceirosService
    {
        protected readonly IParceirosRepository _repository;

        public ParceirosService(IParceirosRepository repository, IActionContextAccessor actionContextAccessor) : base(actionContextAccessor)
        {
            _repository = repository;
        }

        public PagedResult<Parceiro> GetParceiros(PagingParameters model) => _repository.GetParceiros(model);

        public PagedResult<Parceiro> GetParceiro(int idParceiro) => _repository.GetParceiro(idParceiro);
    }
}
