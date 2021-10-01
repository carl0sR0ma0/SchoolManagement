using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Enums;
using SchoolManagement.Domain.Validators;
using SchoolManager.Core.Exceptions;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Domain.Models
{
    public class Colaborador : Pessoa
    {
        protected Colaborador() 
        {
        }
        public Colaborador (string _nome, DateTime _dataNascimento, string _rg, string _cpf, Sexo _sexo, string _telefone, string _ctps, string _cargo, DateTime _dataAdmissao)
        {
            Nome = _nome;
            DataNascimento = _dataNascimento;
            RG = _rg;
            CPF = _cpf;
            Sexo = _sexo;
            Telefone = _telefone;
            Ctps = _ctps;
            Cargo = _cargo;
            DataAdmissao = _dataAdmissao; 
            _errors = new List<string>();

            Validate();
        }

        public string Ctps { get; set; }
        public string Cargo { get; set; }
        public DateTime DataAdmissao { get; set; }

        public override bool Validate()
        {
            var validator = new ColaboradorValidator();
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
