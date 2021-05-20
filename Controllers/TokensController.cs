﻿using API_Investidor.Models.Token;
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
    public class TokensController : RootController
    {
        private readonly ITokensService _service;

        public TokensController(ITokensService servicd)
        {
            _service = servicd;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult ObterCodigo([FromBody] TokenAskCode dados)
        {
            _service.GerarTokenAsync(dados);
            return CustomResponse();
        }
    }
}
