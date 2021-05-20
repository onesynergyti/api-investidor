using API_Investidor.Data;
using API_Investidor.Models;
using API_Investidor.Models.Categorias;
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
    public class CategoriasController : RootController
    {
        private readonly ICategoriasService _service;

        public CategoriasController(ICategoriasService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedResult<Categoria>))]
        public IActionResult Get([FromQuery] FiltroCategoriasModel model) => CustomResponse(_service.GetCategorias(model));

        [HttpGet("{idCategoria}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Categoria))]
        public IActionResult Get(int idCategoria) => CustomResponse(_service.GetCategoria(idCategoria));
    }
}
