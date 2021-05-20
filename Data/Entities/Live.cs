using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_Investidor.Data.Entities
{
    public class Live
    {
        public int IDLIVE { get; set; }

        public int? IDCLIENTE { get; set; }

        public string DESCRICAO_BREVE { get; set; }

        public string DESCRICAO_COMPLETA { get; set; }

        public string MINIATURA { get; set; }

        public string LINK { get; set; }

        public string FRAME { get; set; }

        public DateTime? DATACADASTRO { get; set; }

        public DateTime? DATA_LIVE { get; set; }

        public string HORARIO_INICIO { get; set; }

        public string HORARIO_TERMINO { get; set; }

        public string STATUS { get; set; }

        public int? IDCATEGORIA { get; set; }

        public string REGRA { get; set; }

        public int? VIEWS { get; set; } = 0;

        [NotMapped]
        public Cliente CLIENTE { get; set; }

        [NotMapped]
        public Categoria CATEGORIA { get; set; }
    }
}
