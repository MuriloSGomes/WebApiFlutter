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
                Database = @"D:\dbSmartie\SMARTIE.FDB",
                DataSource = "localhost",
                UserID = "SYSDBA",
                Password = "masterkey",
                Port = 3053
            };

            var conexao = new FbConnection(sb.ToString());
            conexao.Open();
            return conexao;
        }
    }
}