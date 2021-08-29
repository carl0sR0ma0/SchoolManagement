using FluentValidation;
using SchoolManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Validators
{
    public class AlunoValidator : AbstractValidator<Aluno>
    {
        public AlunoValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia.");

            RuleFor(x => x.Responsavel)
                .NotEmpty()
                .WithMessage("É obrigatório inserir um responsável.");
        }
    }
}
