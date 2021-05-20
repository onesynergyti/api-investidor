using API_Investidor.Data;
using API_Investidor.Data.Entities;
using API_Investidor.Helpers;
using API_Investidor.Models;
using API_Investidor.Models.Lives;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Investidor.Repositories
{
    public interface ILivesRepository : IRootRepository<Live>
    {
        PagedResult<Live> GetLives(FiltroLivesModel model);

        Live GetLive(int idLive);
    }

    public class LivesRepository : RootRepository<Live>, ILivesRepository
    {
        public LivesRepository(InvestidorContext InvestidorContext) : base(InvestidorContext) { }

        public PagedResult<Live> GetLives(FiltroLivesModel model)
        {
            return _InvestidorContext.live
                .Include(e => e.CLIENTE)
                .Include(e => e.CATEGORIA)
                .Where(e => model.Id == null || e.IDLIVE == model.Id)
                .Where(e => model.Nome == default || e.DESCRICAO_BREVE.Contains(model.Nome))
                .GetPaged(model.PageNumber, model.PageSize);
        }

        public Live GetLive(int idEBook)
        {
            var live = _InvestidorContext.live
                .Where(e => e.IDLIVE == idEBook)
                .FirstOrDefault();

            if (live != null)
            {
                live.VIEWS++;
                Update(live);
            }

            return live;
        }
    }
}
