using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiOficial.Dominios
{
    public class DTOParametroAlteraSenha : DTORetornoPadrao
    {
        public string Token { get; set; }
        public string Senha { get; set; }
    }
}