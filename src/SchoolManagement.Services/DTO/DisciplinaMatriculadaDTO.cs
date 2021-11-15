using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Services.DTO
{
    public class DisciplinaMatriculadaDTO
    {
        public DisciplinaMatriculadaDTO() { }

        public DisciplinaMatriculadaDTO(long id, long disicplinaProfessorId, DisciplinaProfessorDTO disciplinaProfessor, long matriculaId, MatriculaDTO matricula, string horario)
        {
            Id = id;
            DisicplinaProfessorId = disicplinaProfessorId;
            DisciplinaProfessor = disciplinaProfessor;
            MatriculaId = matriculaId;
            Matricula = matricula;
            Horario = horario;
        }

        public long Id { get; set; }
        public long DisicplinaProfessorId { get; set; }
        public DisciplinaProfessorDTO DisciplinaProfessor { get; set; }
        public long MatriculaId { get; set; }
        public MatriculaDTO Matricula { get; set; }
        public string Horario { get; set; }
    }
}
