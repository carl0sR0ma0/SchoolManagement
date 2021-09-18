using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.API.ViewModel.CursoViewModel
{
    public class UpdateCursoViewModel
    {
        [Required(ErrorMessage = "O id não pode ser vazio")]
        [Range(1, long.MaxValue, ErrorMessage = "O id não pode ser menor que 1")]
        public long Id { get; set; }

        [Required(ErrorMessage = "O nome não pode ser nulo")]
        public string Nome { get; set; }

        public string SerieIni { get; set; }
        public string SerieFin { get; set; }
        public string Coordenador { get; set; }
    }
}
