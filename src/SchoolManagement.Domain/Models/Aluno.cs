using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Enums;
using SchoolManagement.Domain.Validators;
using SchoolManager.Core.Exceptions;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Domain.Models
{
    public class Aluno : Pessoa
    {
        // CONSTRUTORES
        protected Aluno() {}

        public Aluno (string _nome, DateTime _dataNascimento, string _rg, string _cpf, Sexo _sexo, string _telefone, long _ra)
        {
            Nome = _nome;
            DataNascimento = _dataNascimento;
            RG = _rg;
            CPF = _cpf;
            Sexo = _sexo;
            Telefone = _telefone;
            RA = _ra;
            _errors = new List<string>();
            Responsavel = new List<Responsavel>();

            Validate();
        }
        // PROPRIEDADES
        public long RA { get; set; }
        public List<Responsavel> Responsavel { get; set; }
        // MÉTODOS
        public void AddReponsavel(Responsavel responsavel)
        {
            this.Responsavel.Add(responsavel);
        }

        public override bool Validate()
        {
            var validator = new AlunoValidator();
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

    public class Responsavel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
    }
}
