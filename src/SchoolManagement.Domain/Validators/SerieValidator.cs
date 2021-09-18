using FluentValidation;
using SchoolManagement.Domain.Models;

namespace SchoolManagement.Domain.Validators
{
    public class SerieValidator : AbstractValidator<Serie>
    {
        public SerieValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia.");

            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("É necessário inserir um nome.")

                .MinimumLength(3)
                .WithMessage("O nome deve ter no mínimo 3 caracteres.");
            
            RuleFor(x => x.Descricao)
                .MinimumLength(10)
                .WithMessage("A descrição deve ter no mínimo 10 caracteres.");
        }
    }
}
