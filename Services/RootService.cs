using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Investidor.Services
{
    public class RootService
    {
        private readonly ModelStateDictionary _modelState;

        public RootService(IActionContextAccessor actionContextAccessor)
        {
            _modelState = actionContextAccessor.ActionContext.ModelState;
        }

        public void AddModelError(string error)
        {
            _modelState.AddModelError(string.Empty, error);
        }
    }
}
