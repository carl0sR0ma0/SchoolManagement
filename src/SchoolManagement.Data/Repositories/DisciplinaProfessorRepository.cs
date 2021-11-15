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
    public class DisciplinaProfessorRepository : Repository<DisciplinaProfessor>, IDisciplinaProfessorRepository
    {
        public DisciplinaProfessorRepository(SchoolManagementContext context) : base(context)
        {
        }
        public virtual async Task<List<DisciplinaProfessor>> Get()
        {
            return await _context.Set<DisciplinaProfessor>()
                .AsNoTracking()
                .ToListAsync();
        }

        public virtual async Task<DisciplinaProfessor> Get(long id)
        {
            // Melhorar o método
            var obj = await _context.Set<DisciplinaProfessor>()
                .AsNoTracking()
                .Where(x => x.Id == id)
                .ToListAsync();

            return obj.FirstOrDefault();
        }
        
        public virtual async Task<List<DisciplinaProfessor>> GetDisciplinasByProfessor(long professorId)
        {
            return await _context.Set<DisciplinaProfessor>()
                .Where(x => x.ProfessorId == professorId)
                .AsNoTracking()
                .ToListAsync();
        }
        
        public virtual async Task<List<DisciplinaProfessor>> GetProfessorByDisciplina(long disciplinaId)
        {
            return await _context.Set<DisciplinaProfessor>()
                .Where(x => x.DisciplinaId == disciplinaId)
                .AsNoTracking()
                .ToListAsync();
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
