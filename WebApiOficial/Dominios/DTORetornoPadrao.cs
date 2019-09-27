using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiOficial.Dominios
{
    public abstract class DTORetornoPadrao
    {
        public int Codigo { get; set; }
        public string Mensagem { get; set; }
    }
}