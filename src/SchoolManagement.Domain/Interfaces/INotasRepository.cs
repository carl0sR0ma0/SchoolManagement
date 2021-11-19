using SchoolManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Interfaces
{
    public interface INotasRepository : IRepository<Nota>
    {
        Task<List<Nota>> Get();
        Task<List<Nota>> GetNotasByAluno(long alunoId);
        Task<List<Nota>> GetNotasByAlunoDisciplina(long alunoId, long disciplinaId);
        Task<List<Nota>> GetNotasByDisciplina(long disciplinaId);
        Task Remove(long alunoId, long disciplinaId);
    }
}
