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
    public class DisciplinaMatriculadaRepository : Repository<DisciplinaMatriculada>, IDisciplinaMatriculadaRepository
    {
        public DisciplinaMatriculadaRepository(SchoolManagementContext context) 
            : base(context) { }

        public virtual async Task<List<DisciplinaMatriculada>> Get()
        {
            return await _context.Set<DisciplinaMatriculada>()
                .AsNoTracking()
                .Include(x => x.DisciplinaProfessor)
                .ToListAsync();
        }

        public virtual async Task<DisciplinaMatriculada> Get(long id)
        {
            var obj = await _context.Set<DisciplinaMatriculada>()
                .AsNoTracking()
                .Include(x => x.DisciplinaProfessor)
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
