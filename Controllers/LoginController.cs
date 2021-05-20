using API_Investidor.Models.Login;
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
    public class LoginController : RootController
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("AskCode")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AskCode([FromBody] LoginAskCode dados) => CustomResponse(_loginService.GerarToken(dados));

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Login([FromBody] LoginCheckCode dados) => CustomResponse(/*_loginService.ValidarCodigo(dados)*/);
    }
}
