using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Enums;
using SchoolManagement.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Models
{
    public class Aluno : Pessoa
    {
        // CONSTRUTORES
        public Aluno() {}

        //public Aluno(long RA, List<Responsavel> responsavel)
        //{
        //    this.RA = RA;
        //    this.Responsavel = new List<Responsavel>();
        //}

        public Aluno (string _nome, DateTime _dataNascimento, string _rg, string _cpf, Sexo _sexo, string _telefone, long _ra)
        {
            this.Nome = _nome;
            this.DataNascimento = _dataNascimento;
            this.RG = _rg;
            this.CPF = _cpf;
            this.Sexo = _sexo;
            this.Telefone = _telefone;
            this.RA = _ra;
            this.Responsavel = new List<Responsavel>();
            this._errors = new List<string>();
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
                throw new Exception("Alguns campos estão inválidos, por favor corrija-os! " + this._errors[0]);
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
