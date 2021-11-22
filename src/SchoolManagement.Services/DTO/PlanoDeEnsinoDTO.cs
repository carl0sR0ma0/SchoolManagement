using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Services.DTO
{
    public class PlanoDeEnsinoDTO
    {
        protected PlanoDeEnsinoDTO() { }

        public PlanoDeEnsinoDTO(long turmaId, TurmaDTO turma, DisciplinaDTO disciplina, long disciplinaId, string dia, string horario, int qtdAulas)
        {
            TurmaId = turmaId;
            Turma = turma;
            Disciplina = disciplina;
            DisciplinaId = disciplinaId;
            Dia = dia;
            Horario = horario;
            QtdAulas = qtdAulas;
        }

        public long TurmaId { get; set; }
        public TurmaDTO Turma { get; set; }
        public long DisciplinaId { get; set; }
        public DisciplinaDTO Disciplina { get; set; }
        public string Dia { get; set; }
        public string Horario { get; set; }
        public int QtdAulas { get; set; }
    }
}
