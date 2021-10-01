using SchoolManagement.Domain.Enums;
using System;

namespace SchoolManagement.Services.DTO
{
    public class ColaboradorDTO
    {
        public ColaboradorDTO() { }

        public ColaboradorDTO(long id, string nome, DateTime dataNascimento, string rG, string cPF, Sexo sexo, string telefone, string ctps, string cargo, DateTime dataAdmissao)
        {
            Id = id;
            Nome = nome;
            DataNascimento = dataNascimento;
            RG = rG;
            CPF = cPF;
            Sexo = sexo;
            Telefone = telefone;
            Ctps = ctps;
            Cargo = cargo;
            DataAdmissao = dataAdmissao;

        }

        public long Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public Sexo Sexo { get; set; }
        public string Telefone { get; set; }
        public string Ctps { get; set; }
        public string Cargo { get; set; }
        public DateTime DataAdmissao { get; set; }
    }
}
