using System;

namespace API_Investidor.Data
{
    public class Categoria
    {
        public int IDCATEGORIA { get; set; }

        public string NOMECATEGORIA { get; set; }

        public char? STATUS { get; set; }

        public DateTime? DATACADASTRO { get; set; }
    }
}
