using API_Investidor.Data;
using API_Investidor.Models;
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
    public class ParceirosController : RootController
    {
        private readonly IParceirosService _service;

        public ParceirosController(IParceirosService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedResult<Parceiro>))]
        public IActionResult Get([FromQuery] PagingParameters model) => CustomResponse(_service.GetParceiros(model));
    }
}