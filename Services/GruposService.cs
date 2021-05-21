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
    public interface IGruposService
    {
        PagedResult<Grupo> GetGrupos(PagingParameters model);
    }

    public class GruposService : RootService, IGruposService
    {
        protected readonly IGruposRepository _repository;

        public GruposService(IGruposRepository repository, IActionContextAccessor actionContextAccessor) : base(actionContextAccessor)
        {
            _repository = repository;
        }

        public PagedResult<Grupo> GetGrupos(PagingParameters model) => _repository.GetGrupos(model);
    }
}
