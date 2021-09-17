using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.API.ViewModel.SerieViewModel
{
    public class UpdateSerieViewModel
    {
        [Required(ErrorMessage = "O id não pode ser vazio")]
        [Range(1, long.MaxValue, ErrorMessage = "O id não pode ser menor que 1")]
        public long Id { get; set; }

        [Required(ErrorMessage = "O nome não pode ser nulo")]
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public long CursoId { get; set; }
    }
}
