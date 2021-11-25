using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data.ORM;
using SchoolManagement.Domain.Interfaces;
using SchoolManagement.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Data.Repositories
{
    public class ProfessorRepository : Repository<Professor>, IProfessorRepository
    {
        public ProfessorRepository(SchoolManagementContext context) : base(context) { }
        public virtual async Task<List<Professor>> Get()
        {
            return await _context.Set<Professor>()
                .AsNoTracking()
                .ToListAsync();
        }
        public virtual async Task<Professor> Get(long id)
        {
            var obj = await _context.Set<Professor>()
                .AsNoTracking()
                .Where(x => x.Id == id)
                .ToListAsync();

            return obj.FirstOrDefault();
        }

        public virtual async Task Remove(long id)
        {
            var obj = await Get(id);

            if (obj != null)
            {
                _context.Remove(obj);
                await _context.SaveChangesAsync();
            }
        }
    }
}

