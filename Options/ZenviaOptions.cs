using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Investidor.Options
{
    public class ZenviaOptions
    {
        public string UriSendMessage { get; set; }

        public string Authorization { get; set; }

        public string From { get; set; }

        public string MensagemCodigo { get; set; }

        public string TagCodigo { get; set; }
    }
}
