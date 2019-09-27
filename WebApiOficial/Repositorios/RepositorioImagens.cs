using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiOficial.Dominios;
using WebApiOficial.Utils;

namespace WebApiOficial.Repositorios
{
    public class RepositorioImagens
    {
        public byte[] ObtenhaImagemPorMatricula(DTOParametrosFotoAluno parametros)
        {
            byte[] foto = null;

            var conexao = Conexao.CrieConexao();

            using (var cmd = conexao.CreateCommand())
            {
                cmd.CommandText = $@"SELECT ALUNMATRICULA, I.TIMGIMAGEM
                                    FROM TBALUNO A
                                    INNER JOIN TBIMAGEM I ON I.TIMGID = A.ALUNFOTO
                                    WHERE ALUNMATRICULA = {parametros.Matricula} ";

                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        var teste = dr.GetValue(1);
                        foto = (byte[])teste;
                    }
                }
            }

            return foto;
        }
    }
}