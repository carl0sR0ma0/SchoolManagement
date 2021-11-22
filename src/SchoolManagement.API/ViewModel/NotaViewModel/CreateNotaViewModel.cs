using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.API.ViewModel.DisciplinaViewModel
{
    public class CreateNotaViewModel
    {
        [Required(ErrorMessage = "Aluno não pode ser vazio!")]
        public long AlunoId { get; set; }
        public long DisciplinaId { get; set; }
        public long TurmaId { get; set; }
        public double Nota1 { get; set; }
        public double Nota2 { get; set; }
        public double Nota3 { get; set; }
        public double Nota4 { get; set; }
        public double Media { get; set; }
        public bool AprovadoReprovado { get; set; }
    }
}
