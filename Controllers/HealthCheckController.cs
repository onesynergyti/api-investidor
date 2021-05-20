using API_Investidor.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Investidor.Controllers
{
    [ApiController]
    public class HealthCheckController : RootController
    {
        private readonly InvestidorContext _InvestidorContext;

        public HealthCheckController(InvestidorContext investidorContext)
        {
            _InvestidorContext = investidorContext;
        }

        [HttpGet]
        public IActionResult GetAsync()
        {
            var canConnectDB = _InvestidorContext.Database.CanConnect();

            var response = new
            {
                DataBaseOk = canConnectDB
            };

            return CustomResponse(response);
        }
    }
}
