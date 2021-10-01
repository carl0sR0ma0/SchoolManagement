using FluentValidation;
using SchoolManagement.Domain.Models;

namespace SchoolManagement.Domain.Validators
{
    public class ColaboradorValidator : AbstractValidator<Colaborador>
    {
        public ColaboradorValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia.");
        }
    }
}
