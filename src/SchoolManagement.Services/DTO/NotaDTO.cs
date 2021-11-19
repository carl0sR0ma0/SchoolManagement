using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Services.DTO
{
   public class NotaDTO
    {
        public NotaDTO() { }

        public NotaDTO(long alunoId, AlunoDTO aluno, long disciplinaMatriculadaId, DisciplinaMatriculadaDTO disciplinaMatriculada, double nota1, double nota2, double nota3, double nota4, double media, bool aprovadoReprovado)
        {
            AlunoId = alunoId;
            Aluno = aluno;
            DisciplinaMatriculadaId = disciplinaMatriculadaId;
            DisciplinaMatriculada = disciplinaMatriculada;
            Nota1 = nota1;
            Nota2 = nota2;
            Nota3 = nota3;
            Nota4 = nota4;
            Media = media;
            AprovadoReprovado = aprovadoReprovado;
        }

        public long AlunoId { get; set; }
        public AlunoDTO Aluno { get; set; }
        public long DisciplinaMatriculadaId { get; set; }
        public DisciplinaMatriculadaDTO DisciplinaMatriculada { get; set; }

        public double Nota1 { get; set; }
        public double Nota2 { get; set; }
        public double Nota3 { get; set; }
        public double Nota4 { get; set; }
        public double Media { get; set; }
        public bool AprovadoReprovado { get; set; }
    }
}
