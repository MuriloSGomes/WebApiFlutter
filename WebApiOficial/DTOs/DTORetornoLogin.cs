using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiOficial.Dominios
{
    public class DTORetornoLogin : DTORetornoPadrao
    {
        public string Token { get; set; }
    }
}