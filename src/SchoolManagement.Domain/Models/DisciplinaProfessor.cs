using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Validators;
using SchoolManager.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Models
{
    public class DisciplinaProfessor : Base
    {
        protected  DisciplinaProfessor()
        {
        }

        public DisciplinaProfessor(long professorId, long disciplinaId, string dia, string horario)
        {
            ProfessorId = professorId;
            DisciplinaId = disciplinaId;
            Dia = dia;
            Horario = horario;
            DisciplinaMatriculadas = new List<DisciplinaMatriculada>();
        }

        public long ProfessorId { get; set; }
        public Professor Professor { get; set; }
        public long DisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; }

        public List<DisciplinaMatriculada> DisciplinaMatriculadas { get; set; }

        public string Dia { get; set; }
        public string Horario { get; set; }

        public override bool Validate()
        {
            var validator = new DisciplinaProfessorValidator();
            var validation = validator.Validate(this);

            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                {
                    this._errors.Add(error.ErrorMessage);
                }
                throw new DomainException("Alguns campos estão inválidos, por favor corrija-os! ", this._errors);
            }

            return true;
        }
    }
}
