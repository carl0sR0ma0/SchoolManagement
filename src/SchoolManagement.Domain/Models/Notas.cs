using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Models
{
    public class Notas
    {
        public long AlunoId { get; set; }
        public Aluno Aluno { get; set; }

        public double Nota1 { get; set; }
        public double Nota2 { get; set; }
        public double Nota3 { get; set; }
        public double Nota4 { get; set; }
        public double Media { get; set; }
        public bool AprovadoReprovado { get; set; }
    }
}
