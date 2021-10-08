using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.API.ViewModel.TurmaViewModel
{
    public class UpdateTurmaViewModel
    {
        [Required(ErrorMessage = "O id não pode ser vazio")]
        [Range(1, long.MaxValue, ErrorMessage = "O id não pode ser menor que 1")]
        public long Id { get; set; }

        [Required(ErrorMessage = "O nome não pode ser nulo")]
        public string Nome { get; set; }

        public string Turno { get; set; }
        public string Ano { get; set; }
        public string Sigla { get; set; }
        public string Situacao { get; set; }

        public long SerieId { get; set; }
    }
}

