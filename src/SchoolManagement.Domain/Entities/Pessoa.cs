using SchoolManagement.Domain.Enums;
using SchoolManagement.Domain.Validators;
using SchoolManager.Core.Exceptions;
using System;

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
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }

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
                throw new DomainException("Alguns campos estão inválidos, por favor corrija-os! ", this._errors);
            }

            return true;
        }
    }
}
