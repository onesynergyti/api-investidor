using API_Investidor.Data;
using API_Investidor.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Investidor.Repositories
{
    public interface ITokensRepository : IRootRepository<Token>
    {
        Token GetClienteToken(int idCliente);
    }

    public class TokensRepository : RootRepository<Token>, ITokensRepository
    {
        public TokensRepository(InvestidorContext InvestidorContext) : base(InvestidorContext) { }

        public Token GetClienteToken(int idCliente)
        {
            return _InvestidorContext.token
                .Where(t => t.IDCLIENTE == idCliente && t.DATAEXPIRA < DateTime.Now)
                .FirstOrDefault();
        }
    }
}
