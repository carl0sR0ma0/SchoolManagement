using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Services.DTO
{
    public class DisciplinaProfessorDTO
    {
        public DisciplinaProfessorDTO() { }

        public DisciplinaProfessorDTO(long id, long professorId, ProfessorDTO professor, long disciplinaId, DisciplinaDTO disciplina, string dia, string horario)
        {
            Id = id;
            ProfessorId = professorId;
            Professor = professor;
            DisciplinaId = disciplinaId;
            Disciplina = disciplina;
            Dia = dia;
            Horario = horario;
            DisciplinaMatriculadas = new List<DisciplinaMatriculadaDTO>();
        }

        public long Id { get; set; }
        public long ProfessorId { get; set; }
        public ProfessorDTO Professor { get; set; }
        public long DisciplinaId { get; set; }
        public DisciplinaDTO Disciplina { get; set; }
        public List<DisciplinaMatriculadaDTO> DisciplinaMatriculadas { get; set; }

        public string Dia { get; set; }
        public string Horario { get; set; }
    }
}
