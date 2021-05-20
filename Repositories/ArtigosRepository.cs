using API_Investidor.Data;
using API_Investidor.Data.Entities;
using API_Investidor.Helpers;
using API_Investidor.Models;
using API_Investidor.Models.Artigos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Investidor.Repositories
{
    public interface IArtigosRepository : IRootRepository<Artigo>
    {
        PagedResult<Artigo> GetArtigos(FiltroArtigosModel model);

        Artigo GetArtigo(int idArtigo);
    }

    public class ArtigosRepository : RootRepository<Artigo>, IArtigosRepository
    {
        public ArtigosRepository(InvestidorContext InvestidorContext) : base(InvestidorContext) { }

        public PagedResult<Artigo> GetArtigos(FiltroArtigosModel model)
        {
            return _InvestidorContext.artigo
                .Include(a => a.CATEGORIA)
                .Include(a => a.CLIENTE)
                .Where(a => model.Id == null || a.IDARTIGO == model.Id)
                .Where(a => model.Nome == default || a.DESCRICAO_BREVE.Contains(model.Nome))
                .Where(a => model.IdCategoria == null || a.IDCATEGORIA == model.IdCategoria)
                .GetPaged(model.PageNumber, model.PageSize);
        }

        public Artigo GetArtigo(int idArtigo)
        {
            var artigo = _InvestidorContext.artigo
                .Include(a => a.CATEGORIA)
                .Include(a => a.CLIENTE)
                .Where(a => a.IDARTIGO == idArtigo)
                .FirstOrDefault();

            if (artigo != null)
            {
                artigo.VIEWS++;
                Update(artigo);
            }

            return artigo;
        }
    }
}
