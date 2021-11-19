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
    public class DisciplinaMatriculada : Base
    {
        protected DisciplinaMatriculada() { }

        public DisciplinaMatriculada(long disicplinaProfessorId, long matriculaId, string horario)
        {
            DisicplinaProfessorId = disicplinaProfessorId;
            MatriculaId = matriculaId;
            Horario = horario;
            Notas = new List<Nota>();
        }

        public long DisicplinaProfessorId { get; set; }
        public virtual DisciplinaProfessor DisciplinaProfessor { get; set; }

        public long MatriculaId { get; set; }
        public virtual Matricula Matricula { get; set; }
        public string Horario { get; set; }
        public List<Nota> Notas { get; set; }

        public override bool Validate()
        {
            var validator = new DisciplinaMatriculadaValidator();
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
