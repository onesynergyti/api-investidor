﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Investidor.Services
{
    public interface ISMTPService
    {
        bool EnviarCodigoEmailAsync(string numero, string codigo);
    }

    public class SMTPService : ISMTPService
    {
        public bool EnviarCodigoEmailAsync(string numero, string codigo)
        {
            return true;
        }
    }
}