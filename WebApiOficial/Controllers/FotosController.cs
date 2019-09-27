using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiOficial.Dominios;
using WebApiOficial.Repositorios;

namespace WebApiOficial.Controllers
{
    public class FotosController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage ObtenhaImagem([FromBody] DTOParametrosFotoAluno parametros)
        {
            var foto = new RepositorioImagens().ObtenhaImagemPorMatricula(parametros);

            if(foto != null)
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new ByteArrayContent(foto);
                response.Content.Headers.Expires = DateTime.Now.AddDays(30);
                return response;
            }

            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }
    }
}
