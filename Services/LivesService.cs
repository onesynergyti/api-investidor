using API_Investidor.Data;
using API_Investidor.Models;
using API_Investidor.Models.Lives;
using API_Investidor.Repositories;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Investidor.Services
{
    public interface ILivesService
    {
        PagedResult<Live> GetLives(FiltroLivesModel model, bool permitePrivado);

        Live GetLive(int idLive, bool permitePrivado);
    }

    public class LivesService : RootService, ILivesService
    {
        protected readonly ILivesRepository _repository;

        public LivesService(ILivesRepository repository, IActionContextAccessor actionContextAccessor) : base(actionContextAccessor)
        {
            _repository = repository;
        }

        public PagedResult<Live> GetLives(FiltroLivesModel model, bool permitePrivado) => _repository.GetLives(model, permitePrivado);

        public Live GetLive(int idLive, bool permitePrivado) => _repository.GetLive(idLive, permitePrivado);
    }
}
