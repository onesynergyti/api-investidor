using API_Investidor.Data;
using API_Investidor.Helpers;
using API_Investidor.Models;
using API_Investidor.Models.Chat;
using API_Investidor.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Investidor.Controllers
{
    [ApiController]
    [Authorize]
    public class ChatController : RootController
    {
        private readonly IChatService _service;

        public ChatController(IChatService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedResult<Chat>))]
        public IActionResult Get([FromQuery] FiltroChatModel model) => CustomResponse(_service.GetMensagens(model, User.GetIdCliente()));

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Post([FromBody] ChatModelPost chat) 
        {
            _service.EnviarMensagens(chat, User.GetIdCliente());
            return CustomResponse();
        }        
    }
}
