using API_Investidor.Data;
using API_Investidor.Models;
using API_Investidor.Models.Clientes;
using API_Investidor.Repositories;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;

namespace API_Investidor.Services
{
    public interface IClientesService
    {
        PagedResult<Cliente> GetClientes(FiltroClientesModel model);

        Cliente GetCliente(int idCliente);

        void Add(ClienteModelPost cliente);

        void Update(ClienteModelPut cliente);

        void Remove(int idCliente);
    }

    public class ClientesService : RootService, IClientesService
    {
        protected readonly IClientesRepository _repository;

        public ClientesService(IClientesRepository repository, IActionContextAccessor actionContextAccessor) : base(actionContextAccessor)
        {
            _repository = repository;
        }

        public PagedResult<Cliente> GetClientes(FiltroClientesModel model) => _repository.GetClientes(model);

        public Cliente GetCliente(int idCliente) => _repository.GetCliente(idCliente);

        public void Add(ClienteModelPost cliente)
        {
            _repository.Add(new Cliente()
            {
                DATACADASTRO = DateTime.Now,
                EMAIL = cliente.EMAIL,
                ICONE = cliente.ICONE,
                IDHOTMART = cliente.IDHOTMART,
                NOMECLIENTE = cliente.NOMECLIENTE,
                PLANO = cliente.PLANO,
                STATUS = 'A',
                TELEFONE = cliente.TELEFONE
            });
        }

        public void Update(ClienteModelPut cliente)
        {
            var clienteAtual = _repository.GetCliente(cliente.IDCLIENTE);

            if (clienteAtual == null)
                AddModelError("Cliente não localizado");
            else
            {
                clienteAtual.IDCLIENTE = cliente.IDCLIENTE;
                clienteAtual.EMAIL = cliente.EMAIL;
                clienteAtual.ICONE = cliente.ICONE;
                clienteAtual.IDHOTMART = cliente.IDHOTMART;
                clienteAtual.NOMECLIENTE = cliente.NOMECLIENTE;
                clienteAtual.PLANO = cliente.PLANO;
                clienteAtual.STATUS = cliente.STATUS;
                clienteAtual.TELEFONE = cliente.TELEFONE;

                _repository.Update(clienteAtual);
            }
        }

        public void Remove(int idCliente)
        {
            var clienteAtual = _repository.GetCliente(idCliente);

            if (clienteAtual == null)
                AddModelError("Cliente não localizado");
            else
                _repository.Remove(clienteAtual);
        }
    }
}
