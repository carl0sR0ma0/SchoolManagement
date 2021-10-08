using SchoolManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.API.ViewModel.ColaboradorViewModel
{
    public class UpdateColaboradorViewModel
    {

        [Required(ErrorMessage = "O Id não pode ser vazio.")]
        [Range(1, long.MaxValue, ErrorMessage = "O Id não pode ser menor que 1.")]
        public long Id { get; set; }
        [Required(ErrorMessage = "O nome não pode ser nulo.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A data de nascimmento não pode ser nula.")]
        public DateTime DataNascimento { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public Sexo Sexo { get; set; }
        public string Telefone { get; set; }
        public long Ctps { get; set; }
        public string Cargo { get; set; }
        public DateTime DataAdmissao { get; set; }
    }
}
