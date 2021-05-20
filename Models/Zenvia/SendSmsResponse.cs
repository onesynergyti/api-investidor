using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Investidor.Models.Zenvia
{
    public class SendSmsResponse
    {
        public string statusCode { get; set; }

        public string statusDescription { get; set; }

        public string detailCode { get; set; }

        public string detailDescription { get; set; }
    }
}
