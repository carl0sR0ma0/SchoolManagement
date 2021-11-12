﻿using FluentValidation;
using SchoolManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Validators
{
    public class DisciplinasMatriculadasValidator : AbstractValidator<DisciplinasMatriculadas>
    {
        public DisciplinasMatriculadasValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia.");

            RuleFor(x => x.ProfessorId)
                .NotEmpty()
                .WithMessage("É necessário inserir o nome.");

            RuleFor(x => x.DisciplinaId)
                .NotEmpty()
                .WithMessage("É necessário inserir o nome.");
        }
    }
}
