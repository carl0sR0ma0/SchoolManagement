using FluentValidation;
using SchoolManagement.Domain.Models;

namespace SchoolManagement.Domain.Validators
{
    public class DisciplinaProfessorValidator : AbstractValidator<DisciplinaProfessor>
    {
        public DisciplinaProfessorValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia.");

            RuleFor(x => x.ProfessorId)
                .NotEmpty()
                .WithMessage("É necessário inserir o professor.");

            RuleFor(x => x.DisciplinaId)
                .NotEmpty()
                .WithMessage("É necessário inserir a disciplina.");
        }
    }
}
