using API_Investidor.Data.Entities;
using API_Investidor.Models;
using API_Investidor.Models.EBooks;
using API_Investidor.Repositories;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace API_Investidor.Services
{
    public interface IEBooksService
    {
        PagedResult<EBook> GetEBooks(FiltroEBooksModel model);

        EBook GetEBook(int idArtigo);
    }

    public class EBooksService : RootService, IEBooksService
    {
        protected readonly IEBooksRepository _repository;

        public EBooksService(IEBooksRepository repository, IActionContextAccessor actionContextAccessor) : base(actionContextAccessor)
        {
            _repository = repository;
        }

        public PagedResult<EBook> GetEBooks(FiltroEBooksModel model) => _repository.GetEBooks(model);

        public EBook GetEBook(int idArtigo) => _repository.GetEBook(idArtigo);
    }
}
