using API_Investidor.Data.Entities;
using API_Investidor.Models;
using API_Investidor.Models.Clientes;
using API_Investidor.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Investidor.Controllers
{
    [ApiController]
    public class ClientesController : RootController
    {
        private readonly IClientesService _service;

        public ClientesController(IClientesService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedResult<Cliente>))]
        public IActionResult Get([FromQuery] FiltroClientesModel model) => CustomResponse(_service.GetClientes(model));

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post([FromBody] ClienteModelPost cliente) {
            _service.Add(cliente);
            return CustomResponse();
        }

        [HttpPut]
        public IActionResult Put([FromBody] ClienteModelPut cliente)
        {
            _service.Update(cliente);
            return CustomResponse();
        }

        [HttpDelete("{idCliente}")]
        public IActionResult Delete(int idCliente)
        {
            _service.Remove(idCliente);
            return CustomResponse();
        }
    }
}
