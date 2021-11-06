using FluentValidation;
using SchoolManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Validators
{
    public class DisciplinaValidator : AbstractValidator<Disciplina>
    {
        public DisciplinaValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia.");

            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("É necessário inserir o nome.");
        }
    }
}
