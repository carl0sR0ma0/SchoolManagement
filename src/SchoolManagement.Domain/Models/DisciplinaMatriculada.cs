using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Validators;
using SchoolManager.Core.Exceptions;

namespace SchoolManagement.Domain.Models
{
    public class DisciplinaMatriculada : Base
    {
        protected DisciplinaMatriculada() { }

        public DisciplinaMatriculada(long disciplinaId, long matriculaId, string horario)
        {
            DisciplinaId = disciplinaId;
            MatriculaId = matriculaId;
            Horario = horario;
        }

        public long DisciplinaId { get; set; }
        public virtual Disciplina Disciplina { get; set; }

        public long MatriculaId { get; set; }
        public virtual Matricula Matricula { get; set; }
        public string Horario { get; set; }

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
