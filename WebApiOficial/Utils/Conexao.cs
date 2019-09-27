using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiOficial.Utils
{
    public class Conexao
    {
        public static FbConnection CrieConexao()
        {

            var sb = new FbConnectionStringBuilder()
            {
                Database = @"D:\CelsoGomesPC\BDCOLEGIOVISAO1.FDB",
                DataSource = "localhost",
                UserID = "SYSDBA",
                Password = "masterkey"
            };

            var conexao = new FbConnection(sb.ToString());
            conexao.Open();
            return conexao;
        }
    }
}