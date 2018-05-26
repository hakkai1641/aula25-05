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
            String[] Materias = new string[] { "Arquitetura de Software", "Desenvolvimento de Sistemas em C#", "Banco de Dados" };
            while (total --> 0)
            {
                Aluno aluno = new Aluno();
                aluno.nome = "Nome " + r.Next(100);
                aluno.Matricula_Aluno = r.Next(500).ToString();
                aluno.data_nascimento = dataInicial.AddDays(r.Next((int)tempo.TotalDays));

                alunos.Add(aluno);
                
                foreach (var Materia in Materias)
                {
                    int totalProvas = 10;
                    while(totalProvas -- > 0)
                    {
                        Prova p = new Prova();
                        p.Materia = Materia;
                        p.Nota = r.Next(9) + r.NextDouble();
                        aluno.Provas.Add(p);
                    }
                }

            }
            #region"LINQ"
            var maioresDe18 = from a in alunos where (DateTime.Now - a.data_nascimento).TotalDays > (365 * 18) orderby a.nome ascending select a.nome;
            var maioresDe18Ordenado = from a in alunos where (DateTime.Now - a.data_nascimento).TotalDays > (365 * 18) orderby a.nome ascending select new { Nome = a.nome, Idade = DateTime.Now - a.data_nascimento};
            var provas = from a in alunos where (DateTime.Now - a.data_nascimento).TotalDays > (365 * 18) select a.Provas;
            #endregion

            #region "LAMBDA"
            var maioresDe18Lambda = alunos.Where(a => (DateTime.Now - a.data_nascimento).TotalDays > (365 * 18)).Select(a => a.nome);
            var ProvasLambda = alunos.Where(a => (DateTime.Now - a.data_nascimento).TotalDays > (365 * 18)).SelectMany(a => a.Provas).GroupBy(p => p.Materia);
            #endregion

            foreach (String nome in maioresDe18)
            {
                Console.WriteLine("Alunos maiores de 18: " + nome);
                
            }
            foreach (var a in maioresDe18Ordenado)
            {
                Console.WriteLine("Alunos maiores de 18 ordenados por idade: " + a.Idade);
            }

            Console.ReadKey();

        }
        
    }
}
