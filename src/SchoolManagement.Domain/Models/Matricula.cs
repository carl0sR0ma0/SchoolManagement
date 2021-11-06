using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Validators;
using SchoolManager.Core.Exceptions;
using System;

namespace SchoolManagement.Domain.Models
{
    public class Matricula : Base
    {
        protected Matricula()
        {
        }

        public Matricula(DateTime data, string situcao, string observacao, long alunoId, long turmaId)
        {
            Data = data;
            Situcao = situcao;
            Observacao = observacao;
            AlunoId = alunoId;
            TurmaId = turmaId;
        }

        public DateTime Data { get; set; }
        public string Situcao { get; set; } // Torna-lo um Enumeration (1 - ABERTA, 2- FECHADA, 3- ANDAMENTO, 4- OUTROS...)
        public string Observacao { get; set; }

        public long AlunoId { get; set; }
        public Aluno Aluno { get; set; }

        public long TurmaId { get; set; }
        public Turma Turma { get; set; }

        public override bool Validate()
        {
            var validator = new MatriculaValidator();
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
