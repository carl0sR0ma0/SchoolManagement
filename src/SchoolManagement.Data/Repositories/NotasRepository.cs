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
                .Where(d => d.AlunoId == alunoId)
                .ToListAsync();
        }

        public async Task<List<Nota>> GetNotasByAlunoDisciplina(long alunoId, long disciplinaId)
        {
            return await _context.Set<Nota>()
               .AsNoTracking()
               .Where(d => d.AlunoId == alunoId && d.DisciplinaMatriculadaId == disciplinaId)
               .ToListAsync();
        }

        public async Task <List<Nota>> GetNotasByDisciplina(long disciplinaId)
        {
            return await _context.Set<Nota>()
               .AsNoTracking()
               .Where(d => d.DisciplinaMatriculadaId == disciplinaId)
               .ToListAsync();
        }

        public async Task Remove(long alunoId, long disciplinaId)
        {
            var obj = await GetNotasByAlunoDisciplina(alunoId, disciplinaId);
            if (obj != null)
            {
                _context.Remove(obj);
                await _context.SaveChangesAsync();
            }
        }
    }
}
