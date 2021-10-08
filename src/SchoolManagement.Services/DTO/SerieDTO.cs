using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SchoolManagement.Services.DTO
{
    public class SerieDTO
    {
        public SerieDTO()
        { }

        public SerieDTO(long id, string nome, string descricao, long cursoId, CursoDTO curso)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            CursoId = cursoId;
            Curso = curso;
        }

        public long Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public long CursoId { get; set; }
        public CursoDTO Curso { get; set; }
    }
}
