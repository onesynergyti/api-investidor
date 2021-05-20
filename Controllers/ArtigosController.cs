using API_Investidor.Data.Entities;
using API_Investidor.Models;
using API_Investidor.Models.Artigos;
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
    public class ArtigosController : RootController
    {
        private readonly IArtigosService _service;

        public ArtigosController(IArtigosService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedResult<Artigo>))]
        public IActionResult Get([FromQuery] FiltroArtigosModel model) => CustomResponse(_service.GetArtigos(model));

        [HttpGet("{idArtigo}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Artigo))]
        public IActionResult GetId(int idArtigo) => CustomResponse(_service.GetArtigo(idArtigo));
    }
}
