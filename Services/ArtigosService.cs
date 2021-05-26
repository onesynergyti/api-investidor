using API_Investidor.Data;
using API_Investidor.Models;
using API_Investidor.Models.Artigos;
using API_Investidor.Repositories;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace API_Investidor.Services
{
    public interface IArtigosService
    {
        PagedResult<Artigo> GetArtigos(FiltroArtigosModel model, bool permitePrivado);

        PagedResult<Artigo> GetArtigo(int idArtigo, bool permitePrivado);
    }

    public class ArtigosService : RootService, IArtigosService
    {
        protected readonly IArtigosRepository _repository;

        public ArtigosService(IArtigosRepository repository, IActionContextAccessor actionContextAccessor) : base(actionContextAccessor)
        {
            _repository = repository;
        }

        public PagedResult<Artigo> GetArtigos(FiltroArtigosModel model, bool permitePrivado) => _repository.GetArtigos(model, permitePrivado);

        public PagedResult<Artigo> GetArtigo(int idArtigo, bool permitePrivado) => _repository.GetArtigo(idArtigo, permitePrivado);
    }
}
