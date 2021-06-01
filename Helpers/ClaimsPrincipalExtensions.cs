using System;
using System.Linq;
using System.Security.Claims;

namespace API_Investidor.Helpers
{
    public static class ClaimsPrincipalExtensions
    {
        public static bool GetClienteLogado(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.Claims.Where(c => c.Type == "IdCliente").FirstOrDefault() != null;
        }

        public static int GetIdCliente(this ClaimsPrincipal claimsPrincipal)
        {
            return Convert.ToInt32(claimsPrincipal.Claims.Where(c => c.Type == "idCliente").FirstOrDefault().ToString().Replace("idCliente: ", ""));
        }
    }
}
