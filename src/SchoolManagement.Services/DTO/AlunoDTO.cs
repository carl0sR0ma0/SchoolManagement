using SchoolManagement.Domain.Enums;
using System;

namespace SchoolManagement.Services.DTO
{
    public class AlunoDTO
    {
        public AlunoDTO() { }

        public AlunoDTO(long id, string nome, DateTime dataNascimento, string rG, string cPF, Sexo sexo, string telefone, long rA, string cEP, string logradouro, string numero, string bairro, string cidade)
        {
            Id = id;
            Nome = nome;
            DataNascimento = dataNascimento;
            RG = rG;
            CPF = cPF;
            Sexo = sexo;
            Telefone = telefone;
            RA = rA;
            CEP = cEP;
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
        }

        public long Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public Sexo Sexo { get; set; }
        public string Telefone { get; set; }
        public long RA { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
    }
}
