using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiOficial.Models;
using WebApiOficial.Utils;

namespace WebApiOficial.Repositorios
{
    public class RepositorioAlunoMatriculado
    {
        public List<AlunoMatriculado> ObtenhaAlunosMatriculadosAno2019()
        {
            var conexao = Conexao.CrieConexao();
            var listaDeAlunosMatriculados = new List<AlunoMatriculado>();

            using (FbCommand cmd = conexao.CreateCommand())
            {
                    cmd.CommandText = $@"SELECT ALMTALUNMATRICULA, TA.ALUNNOME, T.SERIDESCRICAO, TU.TURMDESCRICAO
                                        FROM TBALUNOMATRICULADO M
                                        INNER JOIN TBALUNO TA ON TA.ALUNMATRICULA = M.ALMTALUNMATRICULA
                                        INNER JOIN TBSERIE T ON T.SERICODIGO = M.ALMTSERICODIGO
                                        INNER JOIN TBTURMA TU ON TU.TURMCODIGO = M.ALMTTURMCODIGO
                                        WHERE M.ALMTANORANO = 2019";

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var alunoMatriculado = MapeieAlunoMatriculado(dr);
                            listaDeAlunosMatriculados.Add(alunoMatriculado);
                        }
                    }
            }

            return listaDeAlunosMatriculados;
        }

        private AlunoMatriculado MapeieAlunoMatriculado(FbDataReader dr)
        {
            var alunoMatriculado = new AlunoMatriculado();
            alunoMatriculado.Matricula = dr.GetInt32(0);
            alunoMatriculado.Nome = dr.GetString(1);
            alunoMatriculado.Serie = dr.GetString(2);
            alunoMatriculado.Turma = dr.GetString(3);

            return alunoMatriculado;
        }
    }
}