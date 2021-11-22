using SchoolManagement.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Services.Interfaces
{
    public interface INotaService
    {
        Task<NotaDTO> Post(NotaDTO notaDTO);
        Task<NotaDTO> Update(NotaDTO notaDTO);
        Task Remove(long turmaId, long disciplinaId, long alunoId);
        Task<List<NotaDTO>> Get();
        Task<List<NotaDTO>> GetNotasByAluno(long alunoId);
        Task<List<NotaDTO>> GetNotasByDisciplina(long disciplinaId);
        Task<List<NotaDTO>> GetNotasByAlunoDisciplina(long alunoId, long disciplinaId);
        Task<List<NotaDTO>> GetNotasByTurmaDisciplina(long turmaId, long disciplinaId);
        Task<List<NotaDTO>> GetNotasByTurmaAluno(long turmaId, long alunoId);
    }
}
