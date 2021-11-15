using FluentValidation;
using SchoolManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Validators
{
    public class DisciplinaMatriculadaValidator : AbstractValidator<DisciplinaMatriculada>
    {
        public DisciplinaMatriculadaValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia.");

            RuleFor(x => x.DisicplinaProfessorId)
                .NotEmpty()
                .WithMessage("É necessário inserir a Disciplina.");
        }
    }
}
