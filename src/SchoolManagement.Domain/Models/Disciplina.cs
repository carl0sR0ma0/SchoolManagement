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
    public class Disciplina : Base
    {
        protected Disciplina() { }

        public Disciplina(string nome, string sigla, int cargaHoraria, string conteudoProgramatico, string ementa, int aulasSemanais, int faltasPermitidas)
        {
            Nome = nome;
            Sigla = sigla;
            CargaHoraria = cargaHoraria;
            ConteudoProgramatico = conteudoProgramatico;
            Ementa = ementa;
            AulasSemanais = aulasSemanais;
            FaltasPermitidas = faltasPermitidas;
            Professores = new List<DisciplinaProfessor>();
            DisciplinaMatriculadas = new List<DisciplinaMatriculada>();
            Notas = new List<Nota>();
            Turmas = new List<PlanoDeEnsino>();
            _errors = new List<string>();

            Validate();
        }

        public string Nome { get; set; }
        public string Sigla { get; set; }
        public int CargaHoraria { get; set; }
        public string ConteudoProgramatico { get; set; }
        public string Ementa { get; set; }
        public int AulasSemanais { get; set; }
        public int FaltasPermitidas { get; set; }

        public List<DisciplinaProfessor> Professores { get; set; }
        public List<DisciplinaMatriculada> DisciplinaMatriculadas { get; set; }
        public List<Nota> Notas { get; set; }
        public List<PlanoDeEnsino> Turmas { get; set; }

        public override bool Validate()
        {
            var validator = new DisciplinaValidator();
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
