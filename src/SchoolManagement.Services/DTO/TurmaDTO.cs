using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Services.DTO
{
    public class TurmaDTO
    {
        public TurmaDTO()
        {
        }

        public TurmaDTO(long id, string nome, string turno, string ano, string qtdAlunos, string sigla, string situacao)
        {
            Id = id;
            Nome = nome;
            Turno = turno;
            Ano = ano;
            QtdAlunos = qtdAlunos;
            Sigla = sigla;
            Situacao = situacao;
        }

        public long Id { get; set; }
        public string Nome { get; set; }
        public string Turno { get; set; }
        public string Ano { get; set; }
        public string QtdAlunos { get; set; }
        public string Sigla { get; set; }
        public string Situacao { get; set; }
    }
}

