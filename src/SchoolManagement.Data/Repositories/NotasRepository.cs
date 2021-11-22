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
    public class NotasRepository : Repository<Nota>, INotasRepository
    {
        public NotasRepository(SchoolManagementContext context)
            : base(context) { }

        public async Task<List<Nota>> Get()
        {
            return await _context.Set<Nota>()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Nota>> GetNotasByAluno(long alunoId)
        {
            return await _context.Set<Nota>()
                .AsNoTracking()
                .Where(n => n.AlunoId == alunoId)
                .ToListAsync();
        }

        public async Task<List<Nota>> GetNotasByAlunoDisciplina(long alunoId, long disciplinaId)
        {
            return await _context.Set<Nota>()
              .AsNoTracking()
              .Where(n => n.AlunoId == alunoId &&
                          n.DisciplinaId == disciplinaId
                    )
              .ToListAsync();
        }

        public async Task<List<Nota>> GetNotasByTurmaAluno(long turmaId, long alunoId)
        {
            return await _context.Set<Nota>()
              .AsNoTracking()
              .Where(n => n.TurmaId == turmaId &&
                          n.AlunoId == alunoId
                    )
              .ToListAsync();
        }

        public async Task<List<Nota>> GetNotasByTurmaDisciplina(long turmaId, long disciplinaId)
        {
            return await _context.Set<Nota>()
              .AsNoTracking()
              .Where(n => n.TurmaId == turmaId &&
                          n.DisciplinaId == disciplinaId
                    )
              .ToListAsync();
        }

        public async Task<List<Nota>> GetNotasByDisciplina(long disciplinaId)
        {
            return await _context.Set<Nota>()
                .AsNoTracking()
                .Where(n => n.DisciplinaId == disciplinaId)
                .ToListAsync();
        }

        public async Task Remove(long turmaId, long disciplinaId, long alunoId)
        {
            var obj = await _context.Set<Nota>()
              .AsNoTracking()
              .Where(n => n.TurmaId == turmaId &&
                          n.DisciplinaId == disciplinaId &&
                          n.AlunoId == alunoId
                    )
              .FirstOrDefaultAsync();

            if (obj != null)
            {
                _context.Remove(obj);
                await _context.SaveChangesAsync();
            }
        }
    }
}
