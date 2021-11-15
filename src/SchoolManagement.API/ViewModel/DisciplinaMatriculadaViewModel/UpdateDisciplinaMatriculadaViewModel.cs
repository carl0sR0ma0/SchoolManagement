using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.API.ViewModel.DisciplinaMatriculadaViewModel
{
    public class UpdateDisciplinaMatriculadaViewModel
    {
        [Required(ErrorMessage = "O Id não pode ser vazio!")]
        [Range(1, long.MaxValue, ErrorMessage = "O Id não pode ser menor que 1")]
        public long Id { get; set; }
        public long DisciplinaProfessorId { get; set; }
        public long MatriculaId { get; set; }
        public string Horario { get; set; }
    }
}
