using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace API_Investidor.Controllers
{
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("v{version:apiVersion}/[controller]")]
    public class RootController : ControllerBase
    {
        private ICollection<string> Erros = new List<string>();

        [NonAction]
        protected IActionResult CustomResponse(object result = null, int codigo = 200)
        {
            if (!ModelState.IsValid)
                AddModelErrors(ModelState);

            if (InvalidOpetation())
            {
                return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
                {
                    { "Mensagens", Erros.ToArray()}
                }));
            }            

            if (result == null || result == default)
            {
                switch (codigo)
                {
                    case 201: return Created("Post", result);
                    default: return NoContent();
                }
            }            

            Response.Headers.Add("Access-Control-Expose-Headers", "access-control-allow-origin");

            switch(codigo)
            {
                case 201: return Created("Post", result);
                default: return Ok(result);
            }

        }

        private void AddModelErrors(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var error in erros)
            {
                AddProcessingError(error.ErrorMessage);
            }
        }

        protected void AddProcessingError(string error)
        {
            Erros.Add(error);
        }

        protected void ClearProcessingErrors()
        {
            Erros.Clear();
        }

        private bool InvalidOpetation()
        {
            return Erros.Any();
        }
    }
}
