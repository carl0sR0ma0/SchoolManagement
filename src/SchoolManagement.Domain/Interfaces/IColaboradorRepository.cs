using SchoolManagement.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Interfaces
{
    public interface IColaboradorRepository : IRepository<Colaborador>
    {
        Task<List<Colaborador>> Get();
        Task<Colaborador> Get(long id);
        Task Remove(long id);
    }
}
