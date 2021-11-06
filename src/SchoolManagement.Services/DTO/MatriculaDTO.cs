using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Services.DTO
{
    public class MatriculaDTO
    {
        public MatriculaDTO()
        { }

        public MatriculaDTO(long id, DateTime data, string situcao, string observacao, long alunoId, AlunoDTO aluno, long turmaId, TurmaDTO turma)
        {
            Id = id;
            Data = data;
            Situcao = situcao;
            Observacao = observacao;
            AlunoId = alunoId;
            Aluno = aluno;
            TurmaId = turmaId;
            Turma = turma;
        }

        public long Id { get; set; }
        public DateTime Data { get; set; }
        public string Situcao { get; set; }
        public string Observacao { get; set; }

        public long AlunoId { get; set; }
        public AlunoDTO Aluno { get; set; }

        public long TurmaId { get; set; }
        public TurmaDTO Turma { get; set; }
    }
}
