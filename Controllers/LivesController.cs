using API_Investidor.Data.Entities;
using API_Investidor.Models;
using API_Investidor.Models.Lives;
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
    public class LivesController : RootController
    {
        private readonly ILivesService _service;

        public LivesController(ILivesService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedResult<Live>))]
        public IActionResult Get([FromQuery] FiltroLivesModel model) => CustomResponse(_service.GetLives(model));

        [HttpGet("{idLive}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Live))]
        public IActionResult GetId(int idLive) => CustomResponse(_service.GetLive(idLive));
    }
}
