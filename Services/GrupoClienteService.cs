using API_Investidor.Data;
using API_Investidor.Repositories;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Investidor.Services
{
    public interface IGrupoClienteService
    {
        GrupoCliente GetGrupoCliente(int idCliente, int idGrupo);
    }

    public class GrupoClienteService : RootService, IGrupoClienteService
    {
        protected readonly IGrupoClienteRepository _repository;

        public GrupoClienteService(IGrupoClienteRepository repository, IActionContextAccessor actionContextAccessor) : base(actionContextAccessor)
        {
            _repository = repository;
        }

        public GrupoCliente GetGrupoCliente(int idCliente, int idGrupo) => _repository.GetGrupoCliente(idCliente, idGrupo);
    }
}
