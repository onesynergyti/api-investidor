using API_Investidor.Data;
using API_Investidor.Helpers;
using API_Investidor.Models;
using API_Investidor.Models.EBooks;
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
    public class EBooksController : RootController
    {
        private readonly IEBooksService _service;

        public EBooksController(IEBooksService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedResult<EBook>))]
        public IActionResult Get([FromQuery] FiltroEBooksModel model) => CustomResponse(_service.GetEBooks(model, User.GetClienteLogado()));

        [HttpGet("{idEBook}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EBook))]
        public IActionResult GetId(int idEBook) => CustomResponse(_service.GetEBook(idEBook, User.GetClienteLogado()));
    }
}
