using SchoolManagement.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Interfaces
{
    public interface INotasRepository : IRepository<Nota>
    {
        Task<List<Nota>> Get();
        Task<List<Nota>> GetNotasByAluno(long alunoId);
        Task<List<Nota>> GetNotasByDisciplina(long disciplinaId);
        Task<List<Nota>> GetNotasByAlunoDisciplina(long alunoId, long disciplinaId);
        Task<List<Nota>> GetNotasByTurmaDisciplina(long turmaId, long disciplinaId);
        Task<List<Nota>> GetNotasByTurmaAluno(long turmaId, long alunoId);
        Task Remove(long turmaId, long disciplinaId, long alunoId);
    }
}
