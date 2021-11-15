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
    public class DisciplinaRepository : Repository<Disciplina>, IDisciplinaRepository
    {
        public DisciplinaRepository(SchoolManagementContext context)
            : base(context) { }

        public virtual async Task<List<Disciplina>> Get()
        {
            return await _context.Set<Disciplina>()
                .AsNoTracking()
                .ToListAsync();
        }

        public virtual async Task<Disciplina> Get(long id)
        {
            var obj = await _context.Set<Disciplina>()
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
