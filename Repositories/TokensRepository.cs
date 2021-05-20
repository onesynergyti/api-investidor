using API_Investidor.Data;
using API_Investidor.Data.Entities;
using API_Investidor.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Investidor.Repositories
{
    public interface ITokensRepository : IRootRepository<Token>
    {
        Token GetClienteToken(int idCliente);

        Token ValidarClienteToken(LoginCheckCode loginCheckCode);
    }

    public class TokensRepository : RootRepository<Token>, ITokensRepository
    {
        public TokensRepository(InvestidorContext InvestidorContext) : base(InvestidorContext) { }

        public Token GetClienteToken(int idCliente)
        {
            var dataLimite = DateTime.Now;
            return _InvestidorContext.token
                .Where(t => t.IDCLIENTE == idCliente && t.DATAEXPIRA > dataLimite)
                .FirstOrDefault();
        }

        public Token ValidarClienteToken(LoginCheckCode loginCheckCode)
        {
            var dataLimite = DateTime.Now;
            return _InvestidorContext.token
                .Where(t => t.AUTH == loginCheckCode.Auth && t.CODIGO == loginCheckCode.Code && t.DATAEXPIRA > dataLimite)
                .FirstOrDefault();
        }
    }
}
