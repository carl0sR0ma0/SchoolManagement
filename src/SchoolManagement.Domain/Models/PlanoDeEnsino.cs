using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Models
{
    public class PlanoDeEnsino
    {
        protected PlanoDeEnsino() { }

        public PlanoDeEnsino(long turmaId, long disciplinaId, string dia, string horario, int qtdAulas)
        {
            TurmaId = turmaId;
            DisciplinaId = disciplinaId;
            Dia = dia;
            Horario = horario;
            QtdAulas = qtdAulas;
        }

        public long TurmaId { get; set; }
        public Turma Turma { get; set; }
        public long DisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; }

        public string Dia { get; set; }
        public string Horario { get; set; }
        public int QtdAulas { get; set; }
    }
}
