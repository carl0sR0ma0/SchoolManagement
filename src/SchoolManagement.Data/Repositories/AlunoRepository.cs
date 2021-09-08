using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data.ORM;
using SchoolManagement.Domain.Interfaces;
using SchoolManagement.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Data.Repositories
{
    public class AlunoRepository : Repository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(SchoolManagementContext context) : base(context) { }
        public virtual async Task<List<Aluno>> Get()
        {
            return await _context.Set<Aluno>().AsNoTracking().ToListAsync();
        }
        public virtual async Task<Aluno> Get(long id)
        {
            var obj = await _context.Set<Aluno>()
                .AsNoTracking()
                .Where(x => x.Id == id)
                .ToListAsync();

            return obj.FirstOrDefault();
        }

        public async Task<Aluno> GetByRA(long ra)
        {
            var aluno = await _context.Alunos.Where(x => x.RA == ra).AsNoTracking().ToListAsync();
            return aluno.FirstOrDefault();
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

