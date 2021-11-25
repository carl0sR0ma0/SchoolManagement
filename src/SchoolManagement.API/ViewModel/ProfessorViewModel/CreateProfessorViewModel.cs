using SchoolManagement.API.ViewModel.DisciplinaMatriculadaViewModel;
using SchoolManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.API.ViewModel.ProfessorViewModel
{
    public class CreateProfessorViewModel
    {

        [Required(ErrorMessage = "O nome não pode ser nulo.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A data de nascimento não pode ser nula.")]
        public DateTime DataNascimento { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public Sexo Sexo { get; set; }
        public string Telefone { get; set; }
        public long CTPS { get; set; }
        public string Licenca { get; set; }
        public string Titulacao { get; set; }
        public DateTime DataAdmissao { get; set; }
        public List<CreateDisciplinaProfessorViewModel> Disciplinas { get; set; }
    }
}

