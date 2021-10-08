using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Enums;
using SchoolManagement.Domain.Validators;
using SchoolManager.Core.Exceptions;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Domain.Models
{
    public class Professor : Funcionario
    {
        protected Professor() 
        {
        }
        public Professor (string _nome, DateTime _dataNascimento, string _rg, string _cpf, Sexo _sexo, string _telefone, long _ctps, string _licenca, string _titulacao, DateTime _dataAdmissao)
        {
            Nome = _nome;
            DataNascimento = _dataNascimento;
            RG = _rg;
            CPF = _cpf;
            Sexo = _sexo;
            Telefone = _telefone;
            CPTS = _ctps;
            Licenca = _licenca;
            Titulacao = _titulacao;
            DataAdmissao = _dataAdmissao; 
            _errors = new List<string>();

            Validate();
        }

        public string Licenca { get; set; }
        public string Titulacao { get; set; }

        public override bool Validate()
        {
            var validator = new ProfessorValidator();
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
