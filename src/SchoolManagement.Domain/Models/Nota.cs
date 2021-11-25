using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Models
{
    public class Nota
    {
        protected Nota() {}

        public Nota(long alunoId, long disciplinaId, long turmaId, double? nota1, double? nota2, double? nota3, double? nota4, double? media, bool? aprovadoReprovado)
        {
            AlunoId = alunoId;
            DisciplinaId = disciplinaId;
            TurmaId = turmaId;
            Nota1 = nota1;
            Nota2 = nota2;
            Nota3 = nota3;
            Nota4 = nota4;
            Media = media;
            AprovadoReprovado = aprovadoReprovado;
        }

        public long AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        public long DisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; }
        public long TurmaId { get; set; }
        public Turma Turma { get; set; }

        public double? Nota1 { get; set; }
        public double? Nota2 { get; set; }
        public double? Nota3 { get; set; }
        public double? Nota4 { get; set; }
        public double? Media { get; set; }
        public bool? AprovadoReprovado { get; set; }
    }
}
