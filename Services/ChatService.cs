using API_Investidor.Data;
using API_Investidor.Models;
using API_Investidor.Models.Chat;
using API_Investidor.Repositories;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Investidor.Services
{
    public interface IChatService
    {
        PagedResult<Chat> GetMensagens(FiltroChatModel model, int idCliente);

        void EnviarMensagens(ChatModelPost chat, int idCliente);
    }

    public class ChatService : RootService, IChatService
    {
        protected readonly IChatRepository _repository;

        public ChatService(IChatRepository repository, IActionContextAccessor actionContextAccessor) : base(actionContextAccessor)
        {
            _repository = repository;
        }

        public PagedResult<Chat> GetMensagens(FiltroChatModel model, int idCliente) => _repository.GetMensagens(model, idCliente);

        public void EnviarMensagens(ChatModelPost chat, int idCliente)
        {
            _repository.Add(Chat.ConverterParaEntity(chat, idCliente));
        }
    }

}
