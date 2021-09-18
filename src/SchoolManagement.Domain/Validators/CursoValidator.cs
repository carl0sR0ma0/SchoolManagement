using FluentValidation;
using SchoolManagement.Domain.Models;

namespace SchoolManagement.Domain.Validators
{
    public class CursoValidator : AbstractValidator<Curso>
    {
        public CursoValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia.");

            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("É necessário inserir um nome.")

                .MinimumLength(3)
                .WithMessage("O nome deve ter no mínimo 3 caracteres.");
        }
    }
}
