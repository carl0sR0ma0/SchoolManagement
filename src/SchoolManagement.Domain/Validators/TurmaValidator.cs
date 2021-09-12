using FluentValidation;
using SchoolManagement.Domain.Models;

namespace SchoolManagement.Domain.Validators
{
    public class TurmaValidator : AbstractValidator<Turma>
    {
        public TurmaValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia.");

            //RuleFor(x => x.Responsavel)
            //    .NotEmpty()
            //    .WithMessage("É obrigatório inserir um responsável.");
        }
    }
}