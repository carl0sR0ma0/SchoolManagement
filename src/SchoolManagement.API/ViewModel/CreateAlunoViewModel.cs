using SchoolManagement.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.API.ViewModel
{
    public class CreateAlunoViewModel
    {
        [Required(ErrorMessage = "O nome não pode ser nulo.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A data de nascimmento não pode ser nula.")]
        public DateTime DataNascimento { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public Sexo Sexo { get; set; }
        public string Telefone { get; set; }
        public long RA { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
    }
}
