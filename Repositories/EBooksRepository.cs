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

        EBook GetEBook(int idEBook, bool permitePrivado);
    }

    public class EBooksRepository : RootRepository<EBook>, IEBooksRepository
    {
        public EBooksRepository(InvestidorContext InvestidorContext) : base(InvestidorContext) { }

        public PagedResult<EBook> GetEBooks(FiltroEBooksModel model, bool permitePrivado)
        {
            return _InvestidorContext.ebook
                .Include(e => e.CLIENTE)
                .Where(e => model.Id == null || e.IDEBOOK == model.Id)
                .Where(e => model.Nome == default || e.TITULO.Contains(model.Nome))
                .Where(e => permitePrivado || e.REGRA == REGRA_PUBLICA)
                .GetPaged(model.PageNumber, model.PageSize);
        }

        public EBook GetEBook(int idEBook, bool permitePrivado)
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

            return ebook;
        }
    }
}
