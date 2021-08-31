using FluentValidation;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Domain.Validators
{
    public class PessoaValidator : AbstractValidator<Pessoa>
    {
        public PessoaValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia.")

                .NotNull()
                .WithMessage("A entidade não pode ser nula.");
            // Validação do campo Nome
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("É necessário inserir um nome.")

                .NotNull()
                .WithMessage("O nome não pode ser nulo.");
            // Validação do campo Data Nascimento
            RuleFor(x => x.DataNascimento)
                .NotEmpty()
                .WithMessage("É necessário inserir a data de nascimento.")

                .NotNull()
                .WithMessage("A data de nascimmento não pode ser nula.");
        }
    }
}
