using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_Investidor.Data
{
    public partial class Chat
    {
        public int IDMENSAGEM { get; set; }

        public int? IDGRUPO { get; set; }

        public int? IDCLIENTE { get; set; }

        [Required]
        public string MENSAGEM { get; set; }

        public string IMAGEM { get; set; }

        public string AUDIO { get; set; }

        public DateTime? DATA { get; set; }

        public char? STATUS { get; set; }

        [NotMapped]
        public Grupo GRUPO { get; set; }

        [NotMapped]
        public Cliente CLIENTE { get; set; }
    }
}
