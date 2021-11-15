using SchoolManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Interfaces
{
    public interface IDisciplinaMatriculadaRepository : IRepository<DisciplinaMatriculada>
    {
        Task<List<DisciplinaMatriculada>> Get();
        Task<DisciplinaMatriculada> Get(long id);
        Task Remove(long id);
    }
}
