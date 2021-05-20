using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Investidor.Models.Zenvia
{
    public class SendSmsRequest
    {
        public string from { get; set; }

        public string to { get; set; }

        public DateTime? schedule { get; set; }

        public string msg { get; set; }

        public string callbackOption { get; set; } = "NONE"; // Valor padrão sem callback

        public string id { get; set; }

        public string aggregateId { get; set; }

        public bool flashSms { get; set; }

        public int dataCoding { get; set; } = 8; // Mensagem acentuada até 70 caracteres
    }
}
