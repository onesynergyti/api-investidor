using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_Investidor.Data.Entities
{
    public class Artigo
    {
        public int IDARTIGO { get; set; }

        public int? IDCLIENTE { get; set; }

        public int? IDCATEGORIA { get; set; }

        public string TITULO { get; set; }

        public string DESCRICAO_BREVE { get; set; }

        public string DESCRICAO_COMPLETA { get; set; }

        public string MINIATURA { get; set; }

        public int? IDPARCEIRO { get; set; }

        public DateTime? DATACADASTRO { get; set; }

        public char? STATUS { get; set; }

        public char? DESTAQUE { get; set; }

        public string REGRA { get; set; }

        public int VIEWS { get; set; } = 0;

        [NotMapped]
        public Cliente CLIENTE { get; set; }

        [NotMapped]
        public Categoria CATEGORIA { get; set; }
    }
}
