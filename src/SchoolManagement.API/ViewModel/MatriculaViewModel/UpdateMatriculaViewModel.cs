using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.API.ViewModel.MatriculaViewModel
{
    public class UpdateMatriculaViewModel
    {
        [Required(ErrorMessage = "O Id não pode ser vazio.")]
        [Range(1, long.MaxValue, ErrorMessage = "O Id não pode ser menor que 1.")]
        public long Id { get; set; }

        public DateTime Data { get; set; }
        public string Situacao { get; set; }
        public string Observacao { get; set; }
        public long AlunoId { get; set; }
        public long TurmaId { get; set; }
    }
}
