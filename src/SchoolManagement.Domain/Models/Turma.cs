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
    public class Turma : Base
    {
        protected Turma() { }

        public Turma(string nome, string turno, string ano, string sigla, string situacao, long serieId)
        {
            Nome = nome;
            Turno = turno;
            Ano = ano;
            Sigla = sigla;
            Situacao = situacao;
            SerieId = serieId;
            Notas = new List<Nota>();
            PlanoDeEnsino = new List<PlanoDeEnsino>();
            _errors = new List<string>();

            Validate();
        }

        public string Nome { get; set; }
        public string Turno { get; set; }
        public string Ano { get; set; }
        public string Sigla { get; set; }
        public string Situacao { get; set; }

        public long SerieId { get; set; }
        public Serie Serie { get; set; }

        public List<Nota> Notas { get; set; }
        public List<PlanoDeEnsino> PlanoDeEnsino { get; set; }

        public override bool Validate()
        {
            var validator = new TurmaValidator();
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
