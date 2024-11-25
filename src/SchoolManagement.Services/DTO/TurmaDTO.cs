﻿using System.Collections.Generic;

namespace SchoolManagement.Services.DTO
{
    public class TurmaDTO
    {
        public TurmaDTO()
        {
        }

        public TurmaDTO(long id, string nome, string turno, string ano, string qtdAlunos, string sigla, string situacao, long serieId, SerieDTO serie)
        {
            Id = id;
            Nome = nome;
            Turno = turno;
            Ano = ano;
            QtdAlunos = qtdAlunos;
            Sigla = sigla;
            Situacao = situacao;
            SerieId = serieId;
            Serie = serie;
            Notas = new List<NotaDTO>();
            PlanoDeEnsino = new List<PlanoDeEnsinoDTO>();
        }

        public long Id { get; set; }
        public string Nome { get; set; }
        public string Turno { get; set; }
        public string Ano { get; set; }
        public string QtdAlunos { get; set; }
        public string Sigla { get; set; }
        public string Situacao { get; set; }

        public long SerieId { get; set; }
        public SerieDTO Serie { get; set; }

        public List<NotaDTO> Notas { get; set; }
        public List<PlanoDeEnsinoDTO> PlanoDeEnsino { get; set; }
    }
}

