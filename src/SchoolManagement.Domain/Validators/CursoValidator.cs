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

            //RuleFor(x => x.Responsavel)
            //    .NotEmpty()
            //    .WithMessage("É obrigatório inserir um responsável.");
        }
    }
}
