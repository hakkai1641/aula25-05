using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoAluno
{
    class Aluno
    {
        public String nome { get; set; }
        public DateTime data_nascimento { get; set; }
        public String Matricula_Aluno { get; set; }

        public List<Prova> Provas { get; set; } = new List<Prova>();

    }
}
