using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiOficial.Dominios
{
    public class DTORetornoResultado : DTORetornoPadrao
    {
        public dynamic Result { get; set; }
    }
}