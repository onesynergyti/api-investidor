using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_Investidor.Data
{
    public class Grupo
    {
        public int IDGRUPO { get; set; }

        public int? IDCATEGORIA { get; set; }

        public string NOMEGRUPO { get; set; }

        public string DESCRICAO { get; set; }

        public string ICONE { get; set; }

        public DateTime? DATACADASTRO { get; set; }

        public char? STATUS { get; set; }

        public char? ENVIARMENSAGEM { get; set; }

        public char? ENVIARAUDIO { get; set; }

        public string REGRA { get; set; }

        [NotMapped]
        public Categoria CATEGORIA { get; set; }

        [NotMapped]
        public ICollection<GrupoCliente> CLIENTESGRUPO { get; set; }
    }
}
