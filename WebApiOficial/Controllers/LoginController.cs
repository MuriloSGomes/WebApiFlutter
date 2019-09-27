using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiOficial.Dominios;
using WebApiOficial.Repositorios;
using WebApiOficial.Utils;

namespace WebApiOficial.Controllers
{
    public class LoginController : ApiController
    {
        [HttpGet]
        [HttpPost]
        public DTORetornoLogin ValideLogin([FromBody] DTOParametrosParametrosLogin parametros)
        {
            var repositorioUsuario = new RepositorioLogin();

            if (repositorioUsuario.EhValido(parametros))
            {
                var token = $"{parametros.Login}|{parametros.Senha}";

                return new DTORetornoLogin()
                {
                    Codigo = 0,
                    Mensagem = "Login realizado com sucesso...",
                    Token = token
                };
            }

            return new DTORetornoLogin()
            {
                Codigo = 1,
                Mensagem = "Falha no login.."
            };
        }

        [HttpGet]
        public DTORetornoLogin AltereSenha([FromBody] DTOParametroAlteraSenha parametros)
        {
            var repositorioLogin = new RepositorioLogin();
            var retorno = new DTORetornoLogin();

            try
            {
                var parametrosLogin = ObtenhaParametrosLogin(parametros.Token);
                var senhaAntigaCriptografada = Criptografia.CriptografeMD5(parametrosLogin.Senha);
                var senhaNovaCriptografada = Criptografia.CriptografeMD5(parametros.Senha);
                repositorioLogin.AltereSenha(parametrosLogin.Login, senhaNovaCriptografada, senhaAntigaCriptografada);
                retorno.Codigo = 0;
                retorno.Mensagem = "Senha Alterada com sucesso...";
                retorno.Token = $"{parametrosLogin.Login}|{parametros.Senha}";

            }
            catch (Exception e)
            {
                retorno.Codigo = 1;
                retorno.Mensagem = $"Não foi possível alterar a senha... {e.Message}";
            }

            return retorno;
        }

        private DTOParametrosParametrosLogin ObtenhaParametrosLogin(string token)
        {
            var tokenLoginESenha = token.Split('|');
            var login = tokenLoginESenha[0];
            var senha = tokenLoginESenha[1];

            return new DTOParametrosParametrosLogin()
            {
                Login = login,
                Senha = senha
            };
        }
    }
}
