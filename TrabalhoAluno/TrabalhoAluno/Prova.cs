using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoAluno
{
    class Prova
    {
        public String Materia { get; set; }
        public Aluno aluno = new Aluno();

        private double _Nota;

        public double Nota
        {
            get
            {
                return _Nota;
            }
            set
            {
                if(value < 0 || value > 10)
                {
                    throw new ArgumentException("Valor inválido");
                }
                else
                {
                    _Nota = value;
                }
            }
        }
    }
}
