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
    public class SerieRepository : Repository<Serie>, ISerieRepository
    {
        public SerieRepository(SchoolManagementContext context) : base(context)
        {
        }
        public virtual async Task<List<Serie>> Get()
        {
            return await _context.Set<Serie>().Include(x => x.Curso).AsNoTracking().ToListAsync();
        }

        public virtual async Task<Serie> Get(long id)
        {
            var obj = await _context.Set<Serie>()
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Include(x => x.Curso)
                .ToListAsync();

            return obj.FirstOrDefault();
        }

        public virtual async Task<List<Serie>> GetSeriesByCourse(long cursoId)
        {
            var obj = await _context.Set<Serie>()
                .AsNoTracking()
                .Where(x => x.CursoId == cursoId)
                .Include(x => x.Curso)
                .ToListAsync();

            return obj.ToList();
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
