using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Services.DTO
{
    public class DisciplinaDTO
    {
        public DisciplinaDTO() { }

        public DisciplinaDTO(long id, string nome, string sigla, int cargaHoraria, string conteudoProgramatico, string ementa, int aulasSemanais, int faltasPermitidas)
        {
            Id = id;
            Nome = nome;
            Sigla = sigla;
            CargaHoraria = cargaHoraria;
            ConteudoProgramatico = conteudoProgramatico;
            Ementa = ementa;
            AulasSemanais = aulasSemanais;
            FaltasPermitidas = faltasPermitidas;
            Professores = new List<DisciplinaProfessorDTO>();
            DisciplinaMatriculadas = new List<DisciplinaMatriculadaDTO>();
            Notas = new List<NotaDTO>();
            Turmas = new List<PlanoDeEnsinoDTO>();
        }

        public long Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public int CargaHoraria { get; set; }
        public string ConteudoProgramatico { get; set; }
        public string Ementa { get; set; }
        public int AulasSemanais { get; set; }
        public int FaltasPermitidas { get; set; }

        public List<DisciplinaProfessorDTO> Professores { get; set; }
        public List<DisciplinaMatriculadaDTO> DisciplinaMatriculadas { get; set; }
        public List<NotaDTO> Notas { get; set; }
        public List<PlanoDeEnsinoDTO> Turmas { get; set; }
    }
}
