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
    public class DisciplinasMatriculadas : Base
    {
        protected  DisciplinasMatriculadas()
        {
        }

        public DisciplinasMatriculadas(long professorId, Professor professor, long disciplinaId, Disciplina disciplina, string dia, string horario, long matriculaId)
        {
            ProfessorId = professorId;
            Professor = professor;
            DisciplinaId = disciplinaId;
            Disciplina = disciplina;
            Dia = dia;
            Horario = horario;
            MatriculaId = matriculaId;
        }

        public long ProfessorId { get; set; }
        public Professor Professor { get; set; }
        public long DisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; }
        public long MatriculaId { get; set; }
        public Matricula Matricula { get; set; }

        public string Dia { get; set; }
        public string Horario { get; set; }

        public override bool Validate()
        {
            var validator = new DisciplinasMatriculadasValidator();
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
