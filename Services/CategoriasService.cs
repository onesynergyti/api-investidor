using API_Investidor.Data.Entities;
using API_Investidor.Models;
using API_Investidor.Models.Categorias;
using API_Investidor.Repositories;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Investidor.Services
{
    public interface ICategoriasService
    {
        PagedResult<Categoria> GetCategorias(FiltroCategoriasModel model);

        Categoria GetCategoria(int idCategoria);
    }

    public class CategoriasService : RootService, ICategoriasService
    {
        protected readonly ICategoriasRepository _repository;

        public CategoriasService(ICategoriasRepository repository, IActionContextAccessor actionContextAccessor) : base(actionContextAccessor)
        {
            _repository = repository;
        }

        public PagedResult<Categoria> GetCategorias(FiltroCategoriasModel model) => _repository.GetCategorias(model);

        public Categoria GetCategoria(int idCategoria) => _repository.GetCategoria(idCategoria);
    }
}
