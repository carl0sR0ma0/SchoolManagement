using SchoolManagement.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Interfaces
{
    public interface IAlunoRepository : IRepository<Aluno>
    {
        Task<List<Aluno>> Get();
        Task<Aluno> Get(long id);
        Task Remove(long id);
        Task<Aluno> GetByRA(long ra);
    }
}
