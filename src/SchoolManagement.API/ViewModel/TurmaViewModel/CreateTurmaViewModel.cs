using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.API.ViewModel.TurmaViewModel
{
    public class CreateTurmaViewModel
    {
        [Required(ErrorMessage = "O nome não pode ser nulo")]
        public string Nome { get; set; }

        public string Turno { get; set; }
        public string Ano { get; set; }
        public string QtdAlunos { get; set; }
        public string Sigla { get; set; }
        public string Situacao { get; set; }
    }
}
