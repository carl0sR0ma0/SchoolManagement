using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data.ORM;
using SchoolManagement.Domain.Interfaces;
using SchoolManagement.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Data.Repositories
{
    public class ColaboradorRepository : Repository<Colaborador>, IColaboradorRepository
    {
        public ColaboradorRepository(SchoolManagementContext context) : base(context) { }
        public virtual async Task<List<Colaborador>> Get()
        {
            return await _context.Set<Colaborador>().AsNoTracking().ToListAsync();
        }
        public virtual async Task<Colaborador> Get(long id)
        {
            var obj = await _context.Set<Colaborador>()
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

