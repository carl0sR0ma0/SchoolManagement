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
    public class Curso : Base
    {
        protected Curso()
        {
        }

        public Curso(string nome, string serieIni, string serieFin, string coordenador)
        {
            Nome = nome;
            SerieIni = serieIni;
            SerieFin = serieFin;
            Coordenador = coordenador;
        }
        public string Nome { get; set; }
        public string SerieIni { get; set; }
        public string SerieFin { get; set; }
        public string Coordenador { get; set; }

        public override bool Validate()
        {
            var validator = new CursoValidator();
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
