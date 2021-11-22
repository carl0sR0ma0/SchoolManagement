using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.API.ViewModel.DisciplinaMatriculadaViewModel
{
    public class CreateDisciplinaMatriculadaViewModel
    {

        public long DisciplinaId { get; set; }
        public long MatriculaId { get; set; }
        public string Horario { get; set; }
    }
}
