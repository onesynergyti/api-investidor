using API_Investidor.Data;
using API_Investidor.Data.Entities;
using API_Investidor.Helpers;
using API_Investidor.Models;
using API_Investidor.Models.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Investidor.Repositories
{
    public interface IClientesRepository : IRootRepository<Cliente>
    {
        PagedResult<Cliente> GetClientes(FiltroClientesModel model);

        Cliente GetCliente(int idCliente);

        Cliente GetClientePorEmaiOuTelefone(string valor);
    }

    public class ClientesRepository : RootRepository<Cliente>, IClientesRepository
    {
        public ClientesRepository(InvestidorContext InvestidorContext) : base(InvestidorContext) {}

        public PagedResult<Cliente> GetClientes(FiltroClientesModel model)
        {
            return _InvestidorContext.cliente
                .Where(c => model.Id == null || c.IDCLIENTE == model.Id)
                .Where(c => model.Nome == null || c.NOMECLIENTE.Contains(model.Nome))
                .OrderBy(c => c.NOMECLIENTE)
                .GetPaged(model.PageNumber, model.PageSize);
        }

        public Cliente GetCliente(int idCliente)
        {
            return _InvestidorContext.cliente.Where(c => c.IDCLIENTE == idCliente).FirstOrDefault();
        }

        public Cliente GetClientePorEmaiOuTelefone(string valor)
        {
            return _InvestidorContext.cliente.Where(c => c.EMAIL == valor || c.TELEFONE == valor).FirstOrDefault();
        }
    }
}
