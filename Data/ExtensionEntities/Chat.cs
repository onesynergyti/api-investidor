using API_Investidor.Models.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Investidor.Data
{
    public partial class Chat
    {
        public static Chat ConverterParaEntity(ChatModelPost chatPost, int idCliente)
        {
            return new Chat()
            {
                AUDIO = chatPost.AUDIO,
                IDCLIENTE = idCliente,
                DATA = DateTime.Now,
                IDGRUPO = chatPost.IDGRUPO,
                IMAGEM = chatPost.IMAGEM,
                MENSAGEM = chatPost.MENSAGEM,
                STATUS = chatPost.STATUS
            };
        }
    }
}
