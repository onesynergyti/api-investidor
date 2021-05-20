using API_Investidor.Data.Entities;
using API_Investidor.Repositories;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Investidor.Services
{
    public interface ITokensService
    {
        Token GetClienteToken(int idCliente);

        void Add(Token token);

        void Update(Token token);
    }

    public class TokensService : RootService, ITokensService
    {
        protected readonly ITokensRepository _repository;

        public TokensService(ITokensRepository repository, IActionContextAccessor actionContextAccessor) : base(actionContextAccessor)
        {
            _repository = repository;
        }

        public Token GetClienteToken(int idCliente) => _repository.GetClienteToken(idCliente);

        public void Add(Token token)
        {
            _repository.Add(token);
        }

        public void Update(Token token)
        {
            _repository.Update(token);
        }
    }
}
