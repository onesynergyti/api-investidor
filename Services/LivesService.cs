using API_Investidor.Data.Entities;
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
        PagedResult<Live> GetLives(FiltroLivesModel model);

        Live GetLive(int idLive);
    }

    public class LivesService : RootService, ILivesService
    {
        protected readonly ILivesRepository _repository;

        public LivesService(ILivesRepository repository, IActionContextAccessor actionContextAccessor) : base(actionContextAccessor)
        {
            _repository = repository;
        }

        public PagedResult<Live> GetLives(FiltroLivesModel model) => _repository.GetLives(model);

        public Live GetLive(int idLive) => _repository.GetLive(idLive);
    }
}
