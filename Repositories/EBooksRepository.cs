using API_Investidor.Data;
using API_Investidor.Helpers;
using API_Investidor.Models;
using API_Investidor.Models.EBooks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Investidor.Repositories
{
    public interface IEBooksRepository : IRootRepository<EBook>
    {
        PagedResult<EBook> GetEBooks(FiltroEBooksModel model, bool permitePrivado);

        PagedResult<EBook> GetEBook(int idEBook, bool permitePrivado);
    }

    public class EBooksRepository : RootRepository<EBook>, IEBooksRepository
    {
        public EBooksRepository(InvestidorContext InvestidorContext) : base(InvestidorContext) { }

        public PagedResult<EBook> GetEBooks(FiltroEBooksModel model, bool permitePrivado)
        {
            var eBooksQuery = _InvestidorContext.ebook
                .Include(e => e.CLIENTE)
                .Where(e => model.Id == null || e.IDEBOOK == model.Id)
                .Where(e => model.Nome == default || e.TITULO.Contains(model.Nome))
                .Where(e => permitePrivado || e.REGRA == REGRA_PUBLICA);

            switch (model.Ordenacao)
            {
                case ETipoOrdenacaoEBook.MaisRecentes:
                    eBooksQuery = eBooksQuery.OrderByDescending(e => e.DATACADASTRO);
                    break;
                case ETipoOrdenacaoEBook.MaisVistos:
                    eBooksQuery = eBooksQuery.OrderByDescending(e => e.CLICKS);
                    break;
                default:
                    eBooksQuery = eBooksQuery.OrderBy(e => e.TITULO);
                    break;
            }

            return eBooksQuery.GetPaged(model.PageNumber, model.PageSize);
        }

        public PagedResult<EBook> GetEBook(int idEBook, bool permitePrivado)
        {
            var ebook = _InvestidorContext.ebook
                .Where(e => e.IDEBOOK == idEBook)
                .Where(e => permitePrivado || e.REGRA == REGRA_PUBLICA)
                .FirstOrDefault();

            if (ebook != null)
            {
                ebook.CLICKS++;
                Update(ebook);
            }

            var ebooks = _InvestidorContext.ebook
                .Where(e => e.IDEBOOK == idEBook)
                .Where(e => permitePrivado || e.REGRA == REGRA_PUBLICA)
                .GetPaged(1, 1);

            return ebooks;
        }
    }
}
