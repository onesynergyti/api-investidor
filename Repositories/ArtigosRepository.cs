using API_Investidor.Data;
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
        PagedResult<Artigo> GetArtigos(FiltroArtigosModel model, bool permitePrivado);

        Artigo GetArtigo(int idArtigo, bool permitePrivado);
    }

    public class ArtigosRepository : RootRepository<Artigo>, IArtigosRepository
    {
        public ArtigosRepository(InvestidorContext InvestidorContext) : base(InvestidorContext) { }

        public PagedResult<Artigo> GetArtigos(FiltroArtigosModel model, bool permitePrivado)
        {
            return _InvestidorContext.artigo
                .Include(a => a.CATEGORIA)
                .Include(a => a.CLIENTE)
                .Where(a => model.Id == null || a.IDARTIGO == model.Id)
                .Where(a => model.Nome == default || a.DESCRICAO_BREVE.Contains(model.Nome))
                .Where(a => model.IdCategoria == null || a.IDCATEGORIA == model.IdCategoria)
                .Where(a => permitePrivado || a.REGRA == REGRA_PUBLICA)
                .GetPaged(model.PageNumber, model.PageSize);
        }

        public Artigo GetArtigo(int idArtigo, bool permitePrivado)
        {
            var artigo = _InvestidorContext.artigo
                .Include(a => a.CATEGORIA)
                .Include(a => a.CLIENTE)
                .Where(a => a.IDARTIGO == idArtigo)
                .Where(a => permitePrivado || a.REGRA == REGRA_PUBLICA)
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
