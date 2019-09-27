using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiOficial.Dominios;
using WebApiOficial.Models;
using WebApiOficial.Repositorios;

namespace WebApiOficial.Controllers
{
    public class AlunosController : ApiController
    {

        [HttpGet]
        public DTORetornoResultado ObtenhaAlunos([FromBody] DTOParametrosListaDeAlunos parametros)
        {
            var repositorioLogin = new RepositorioLogin();

            var parametrosLogin = ObtenhaParametrosLogin(parametros.Token);

            if (repositorioLogin.EhValido(parametrosLogin))
            {
                var alunos = new RepositorioAlunoMatriculado().ObtenhaAlunosMatriculadosAno2019();

                return new DTORetornoResultado()
                {
                    Codigo = 0,
                    Mensagem = string.Empty,
                    Result = alunos
                };
            }

            return new DTORetornoResultado()
            {
                Codigo = 1,
                Mensagem = "Não Autorizado"
            };

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
