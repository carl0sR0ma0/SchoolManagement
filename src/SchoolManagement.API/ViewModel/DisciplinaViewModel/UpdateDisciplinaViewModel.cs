using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.API.ViewModel.DisciplinaViewModel
{
    public class UpdateDisciplinaViewModel
    {
        [Required(ErrorMessage = "O Id não pode ser vazio!")]
        [Range(1, long.MaxValue, ErrorMessage = "O Id não pode ser menor que 1")]
        public long Id { get; set; }

        [Required(ErrorMessage = "O nome não pode ser vazio!")]
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public int CargaHoraria { get; set; }
        public string ConteudoProgramatico { get; set; }
        public string Ementa { get; set; }
        public int AulasSemanais { get; set; }
        public int FaltasPermitidas { get; set; }
    }
}
