using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data.ORM;
using SchoolManagement.Domain.Interfaces;
using SchoolManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Data.Repositories
{
    public class TurmaRepository : Repository<Turma>, ITurmaRepository
    {
        public TurmaRepository(SchoolManagementContext context) : base(context)
        {
        }
        public virtual async Task<List<Turma>> Get()
        {
            return await _context.Set<Turma>().Include(x => x.Serie).AsNoTracking().ToListAsync();
        }

        public virtual async Task<Turma> Get(long id)
        {
            var obj = await _context.Set<Turma>()
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Include(x => x.Serie)
                .ToListAsync();

            return obj.FirstOrDefault();
        }

        public virtual async Task Remove(long id)
        {
            var obj = await Get(id);
            if (obj != null )
            {
                _context.Remove(obj);
                await _context.SaveChangesAsync();
            }
        }
    }
}
