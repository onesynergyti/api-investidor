using API_Investidor.Data;
using API_Investidor.Data.Entities;
using API_Investidor.Helpers;
using API_Investidor.Models;
using API_Investidor.Models.Categorias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Investidor.Repositories
{
    public interface ICategoriasRepository : IRootRepository<Categoria>
    {
        PagedResult<Categoria> GetCategorias(FiltroCategoriasModel model);

        Categoria GetCategoria(int idCategoria);
    }

    public class CategoriasRepository : RootRepository<Categoria>, ICategoriasRepository
    {
        public CategoriasRepository(InvestidorContext InvestidorContext) : base(InvestidorContext) { }

        public PagedResult<Categoria> GetCategorias(FiltroCategoriasModel model)
        {
            return _InvestidorContext.categoria
                .Where(c => model.Id == null || c.IDCATEGORIA == model.Id)
                .Where(c => model.Nome == default || c.NOMECATEGORIA.Contains(model.Nome))
                .OrderBy(c => c.NOMECATEGORIA)
                .GetPaged(model.PageNumber, model.PageSize);
        }

        public Categoria GetCategoria(int idCategoria)
        {
            return _InvestidorContext.categoria.Where(c => c.IDCATEGORIA == idCategoria).FirstOrDefault();
        }
    }
}
