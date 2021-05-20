using API_Investidor.Data.Entities;
using API_Investidor.Models;
using API_Investidor.Models.Artigos;
using API_Investidor.Repositories;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Investidor.Services
{
    public interface IArtigosService
    {
        PagedResult<Artigo> GetArtigos(FiltroArtigosModel model);

        Artigo GetArtigo(int idArtigo);
    }

    public class ArtigosService : RootService, IArtigosService
    {
        protected readonly IArtigosRepository _repository;

        public ArtigosService(IArtigosRepository repository, IActionContextAccessor actionContextAccessor) : base(actionContextAccessor)
        {
            _repository = repository;
        }

        public PagedResult<Artigo> GetArtigos(FiltroArtigosModel model) => _repository.GetArtigos(model);

        public Artigo GetArtigo(int idArtigo) => _repository.GetArtigo(idArtigo);
    }

}
