using API_Investidor.Data;
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
        PagedResult<Live> GetLives(FiltroLivesModel model, bool permitePrivado);

        Live GetLive(int idLive, bool permitePrivado);
    }

    public class LivesRepository : RootRepository<Live>, ILivesRepository
    {
        public LivesRepository(InvestidorContext InvestidorContext) : base(InvestidorContext) { }

        public PagedResult<Live> GetLives(FiltroLivesModel model, bool permitePrivado)
        {
            return _InvestidorContext.live
                .Include(l => l.CLIENTE)
                .Include(l => l.CATEGORIA)
                .Where(l => model.Id == null || l.IDLIVE == model.Id)
                .Where(l => model.Nome == default || l.DESCRICAO_BREVE.Contains(model.Nome))
                .Where(l => permitePrivado || l.REGRA == REGRA_PUBLICA)
                .GetPaged(model.PageNumber, model.PageSize);
        }

        public Live GetLive(int idLive, bool permitePrivado)
        {
            var live = _InvestidorContext.live
                .Where(l => l.IDLIVE == idLive)
                .Where(l => permitePrivado || l.REGRA == REGRA_PUBLICA)
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
