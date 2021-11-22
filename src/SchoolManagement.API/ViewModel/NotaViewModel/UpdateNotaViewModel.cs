using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.API.ViewModel.DisciplinaViewModel
{
    public class UpdateNotaViewModel
    {
        [Required(ErrorMessage = "O Id do Aluno não pode ser vazio!")]
        [Range(1, long.MaxValue, ErrorMessage = "O Id não pode ser menor que 1")]
        public long AlunoId { get; set; }
        
        [Required(ErrorMessage = "É preciso informar o Id da disciplina!")]
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
