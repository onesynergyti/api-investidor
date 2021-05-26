using API_Investidor.Data;
using API_Investidor.Models;
using API_Investidor.Models.EBooks;
using API_Investidor.Repositories;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace API_Investidor.Services
{
    public interface IEBooksService
    {
        PagedResult<EBook> GetEBooks(FiltroEBooksModel model, bool permitePrivado);

        PagedResult<EBook> GetEBook(int idArtigo, bool permitePrivado);
    }

    public class EBooksService : RootService, IEBooksService
    {
        protected readonly IEBooksRepository _repository;

        public EBooksService(IEBooksRepository repository, IActionContextAccessor actionContextAccessor) : base(actionContextAccessor)
        {
            _repository = repository;
        }

        public PagedResult<EBook> GetEBooks(FiltroEBooksModel model, bool permitePrivado) => _repository.GetEBooks(model, permitePrivado);

        public PagedResult<EBook> GetEBook(int idArtigo, bool permitePrivado) => _repository.GetEBook(idArtigo, permitePrivado);
    }
}
