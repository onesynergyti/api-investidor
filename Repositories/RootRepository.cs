using API_Investidor.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Investidor.Repositories
{
    public interface IRootRepository<T>
    {
        void Add(T cliente);

        void Update(T cliente);

        void Remove(T cliente);
    }

    public class RootRepository<T> : IRootRepository<T>
    {
        protected const string REGRA_PUBLICA = "PUBLICO";
        protected readonly InvestidorContext _InvestidorContext;

        public RootRepository(InvestidorContext InvestidorContext)
        {
            _InvestidorContext = InvestidorContext;
        }

        public void Add(T obj)
        {
            _InvestidorContext.Add(obj);
            _InvestidorContext.SaveChanges();
        }

        public void Update(T obj)
        {
            _InvestidorContext.Update(obj);
            _InvestidorContext.SaveChanges();
        }

        public void Remove(T obj)
        {
            _InvestidorContext.Remove(obj);
            _InvestidorContext.SaveChanges();
        }
    }
}
