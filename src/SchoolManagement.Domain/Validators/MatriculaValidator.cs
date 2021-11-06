using FluentValidation;
using SchoolManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Validators
{
    public class MatriculaValidator : AbstractValidator<Matricula>
    {
        public MatriculaValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia.");

            // A data da Matricula não pode ser menor que a data atual
        }
    }
}
