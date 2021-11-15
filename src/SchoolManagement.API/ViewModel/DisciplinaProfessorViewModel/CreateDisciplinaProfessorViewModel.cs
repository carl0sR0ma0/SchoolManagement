using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.API.ViewModel.DisciplinaMatriculadaViewModel
{
    public class CreateDisciplinaProfessorViewModel
    {
        public long ProfessorId { get; set; }
        public long DisciplinaId { get; set; }
        public string Dia { get; set; }
        public string Horario { get; set; }
    }
}
