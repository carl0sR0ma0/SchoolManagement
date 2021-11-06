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
    public class MatriculaRepository : Repository<Matricula>, IMatriculaRepository
    {
        public MatriculaRepository(SchoolManagementContext context) : base(context) { }

        public async Task<List<Matricula>> Get()
        {
            return await _context.Set<Matricula>().Include(x => x.Aluno).Include(x => x.Turma).AsNoTracking().ToListAsync();
        }

        public async Task<Matricula> Get(long id)
        {
            var obj = await _context.Set<Matricula>()
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Include(x => x.Aluno)
                .Include(x => x.Turma)
                .ToListAsync();

            return obj.FirstOrDefault();
        }

        public async Task<Matricula> GetByRA(long ra)
        {
            var obj = await _context.Set<Matricula>()
                .AsNoTracking()
                .Where(x => x.Aluno.RA == ra)
                .ToListAsync();

            return obj.FirstOrDefault();
        }

        public async Task Remove(long id)
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
