using SchoolManagement.Domain.Enums;
using SchoolManagement.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Entities
{
    public abstract class Pessoa : Base
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public Sexo Sexo { get; set; }
        public string Telefone { get; set; }

        public override bool Validate()
        {
            var validator = new PessoaValidator();
            var validation = validator.Validate(this);

            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                {
                    this._errors.Add(error.ErrorMessage);
                }
                throw new Exception("Alguns campos estão inválidos, por favor corrija-os! " + this._errors[0]);
            }

            return true;
        }
    }
}
