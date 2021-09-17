using SchoolManagement.Services.DTO;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.API.ViewModel.SerieViewModel
{
    public class CreateSerieViewModel
    {
        [Required(ErrorMessage = "O nome não pode ser nulo")]
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public long CursoId { get; set; }
    }
}
