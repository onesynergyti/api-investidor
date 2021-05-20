using API_Investidor.Data;
using API_Investidor.Helpers;
using API_Investidor.Models;
using API_Investidor.Models.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Investidor.Repositories
{
    public interface IChatRepository : IRootRepository<Chat>
    {
        PagedResult<Chat> GetMensagens(FiltroChatModel model, int idCliente);
    }

    public class ChatRepository : RootRepository<Chat>, IChatRepository
    {
        public ChatRepository(InvestidorContext InvestidorContext) : base(InvestidorContext) { }

        public PagedResult<Chat> GetMensagens(FiltroChatModel model, int idCliente)
        {
            return _InvestidorContext.chat
                .Where(c => c.IDCLIENTE == idCliente)
                .Where(c => model.IdGrupo == null || c.IDGRUPO == c.IDGRUPO)
                .GetPaged(model.PageNumber, model.PageSize);
        }
    }
}
