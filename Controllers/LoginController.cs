using API_Investidor.Models.Login;
using API_Investidor.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Investidor.Controllers
{
    [ApiController]
    public class LoginController : RootController
    {
        private readonly ILoginService _service;

        public LoginController(ILoginService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Login([FromBody] LoginCheckCode dados) => CustomResponse(_service.GerarJWT(dados), 201);
    }
}
