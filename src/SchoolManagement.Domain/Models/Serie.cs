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
    public class Serie : Base
    {
        protected Serie()
        {
        }

        public Serie(string nome, string descricao, long cursoId)
        {
            Nome = nome;
            Descricao = descricao;
            CursoId = cursoId;
        }

        public string Nome { get; set; }
        public string Descricao { get; set; }

        public long CursoId { get; set; }
        public Curso Curso { get; set; }

        public override bool Validate()
        {
            var validator = new SerieValidator();
            var validation = validator.Validate(this);

            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                {
                    this._errors.Add(error.ErrorMessage);
                }
                throw new DomainException("Alguns campos estão inválidos, por favor os corrija! ", this._errors);
            }
            return true;
        }
    }
}
