using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Investidor.Data
{
    public class GrupoCliente
    {
        public int IDCLIENTE { get; set; }

        public int IDGRUPO { get; set; }

        public string ENVIARAUDIO { get; set; }

        public string ENVIARMENSAGEM { get; set; }

        public DateTime DATACADASTRO { get; set; }

        public string NOTIFICACAO { get; set; }

        public Cliente CLIENTE { get; set; }

        public Grupo GRUPO { get; set; }
    }
}
