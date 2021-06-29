using API_Investidor.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Investidor.Repositories
{
    public interface IGrupoClienteRepository : IRootRepository<GrupoCliente>
    {
        GrupoCliente GetGrupoCliente(int idCliente, int idGrupo);
    }

    public class GrupoClienteRepository : RootRepository<GrupoCliente>, IGrupoClienteRepository
    {
        public GrupoClienteRepository(InvestidorContext InvestidorContext) : base(InvestidorContext) { }


        public GrupoCliente GetGrupoCliente(int idCliente, int idGrupo)
        {
            return _InvestidorContext.grupo_cliente
                .Include(c => c.CLIENTE)
                .Include(g => g.GRUPO)
                .Where(r => r.IDCLIENTE == idCliente && r.IDGRUPO == idGrupo)
                .FirstOrDefault();
        }
    }
}
