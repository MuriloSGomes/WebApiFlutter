using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiOficial.Models
{
    public class AlunoMatriculado
    {
        public int Matricula { get; set; }
        public string  Nome { get; set; }
        public string Serie { get; set; }
        public string Turma { get; set; }
    }
}