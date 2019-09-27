using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiOficial.Dominios;
using FirebirdSql;
using FirebirdSql.Data.FirebirdClient;
using WebApiOficial.Utils;

namespace WebApiOficial.Repositorios
{
    public class RepositorioLogin
    {
        public bool EhValido(DTOParametrosParametrosLogin parametros)
        {
            var sb = new FbConnectionStringBuilder()
            {
                Database = @"D:\dbSmartie\SMARTIE.FDB",
                DataSource = "localhost",
                UserID = "SYSDBA",
                Password = "masterkey",
                Port = 3053
            };

            using (FbConnection cn = new FbConnection(sb.ConnectionString))
            {
                cn.Open();

                using (FbCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = $@"SELECT * FROM USUARIO
                                        WHERE NOME = '{parametros.Login.ToUpper()}' AND SENHA = '{parametros.Senha}'";

                    using (var dr = cmd.ExecuteReader())
                    {
                        return dr.Read();
                    }
                }
            }
        }

        public void AltereSenha(string login, string senhaNova, string senhaAntiga)
        {
            var conexao = Conexao.CrieConexao();

            using (var cmd = conexao.CreateCommand())
            {
                cmd.CommandText = $@"UPDATE USUARIO SET SENHA = '{senhaNova}' WHERE NOME = '{login}' AND SENHA = '{senhaAntiga}'";
                cmd.ExecuteNonQuery();
            }
        } 
    }
}