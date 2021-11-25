using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolManagement.API.ViewModel.DisciplinaMatriculadaViewModel;

namespace SchoolManagement.API.ViewModel.MatriculaViewModel
{
    public class CreateMatriculaViewModel
    {
        public DateTime Data { get; set; }
        public string Situacao { get; set; }
        public string Observacao { get; set; }
        public long AlunoId { get; set; }
        public long TurmaId { get; set; }
        public List<CreateDisciplinaMatriculadaViewModel> DisciplinaMatriculadas { get; set; }
    }
}
