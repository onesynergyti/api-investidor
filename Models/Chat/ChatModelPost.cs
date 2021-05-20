using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Investidor.Models.Chat
{
    public class ChatModelPost
    {
        public int? IDGRUPO { get; set; }

        [Required]
        public string MENSAGEM { get; set; }

        public string IMAGEM { get; set; }

        public string AUDIO { get; set; }

        [Required]
        public char STATUS { get; set; }
    }
}
