using SchoolManagement.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Interfaces
{
    public interface ISerieRepository : IRepository<Serie>
    {
        Task<List<Serie>> Get();
        Task<Serie> Get(long id);
        Task Remove(long id);
        Task<List<Serie>> GetSeriesByCourse(long cursoId);
    }
}
