using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoAluno
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Aluno> alunos = new List<Aluno>();
            int total = 10;
            Random r = new Random();
            DateTime dataInicial = new DateTime(1990, 01, 01);
            DateTime dataFinal = DateTime.Now.AddYears(-16);
            TimeSpan tempo = (dataFinal - dataInicial);
            while (total --> 0)
            {
                Aluno aluno = new Aluno();
                aluno.nome = "Nome " + r.Next(100);
                aluno.Matricula_Aluno = r.Next(500).ToString();
                aluno.data_nascimento = dataInicial.AddDays(r.Next((int)tempo.TotalDays));

                alunos.Add(aluno);

            }

            var maioresDe18 = from a in alunos where (DateTime.Now - a.data_nascimento).TotalDays > (365 * 18) select a;

            foreach (Aluno m in maioresDe18)
            {
                Console.WriteLine("Alunos maiores de 18: " + m.nome);

            }

            Console.ReadKey();

        }
        
    }
}
