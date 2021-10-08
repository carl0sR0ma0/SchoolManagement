using SchoolManagement.Domain.Enums;
using System;

namespace SchoolManagement.Services.DTO
{
    public class ProfessorDTO
    {
        public ProfessorDTO() { }

        public ProfessorDTO(long id, string nome, DateTime dataNascimento, string rG, string cPF, Sexo sexo, string telefone, long ctps, string licenca, string titulacao, DateTime dataAdmissao)
        {
            Id = id;
            Nome = nome;
            DataNascimento = dataNascimento;
            RG = rG;
            CPF = cPF;
            Sexo = sexo;
            Telefone = telefone;
            CTPS = ctps;
            Licenca = licenca;
            Titulacao = titulacao;
            DataAdmissao = dataAdmissao;

        }

        public long Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public Sexo Sexo { get; set; }
        public string Telefone { get; set; }
        public long CTPS { get; set; }
        public string Licenca { get; set; }
        public string Titulacao { get; set; }
        public DateTime DataAdmissao { get; set; }
    }
}
