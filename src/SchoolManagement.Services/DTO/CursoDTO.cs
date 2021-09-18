using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Services.DTO
{
    public class CursoDTO
    {
        public CursoDTO()
        {
        }

        public CursoDTO(long id, string nome, string serieIni, string serieFin, string coordenador)
        {
            Id = id;
            Nome = nome;
            SerieIni = serieIni;
            SerieFin = serieFin;
            Coordenador = coordenador;
            Series = new List<SerieDTO>();
        }

        public long Id { get; set; }
        public string Nome { get; set; }
        public string SerieIni { get; set; }
        public string SerieFin { get; set; }
        public string Coordenador { get; set; }
        public List<SerieDTO> Series { get; set; }
    }
}
