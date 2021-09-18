using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data.ORM;
using SchoolManagement.Domain.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly SchoolManagementContext _context;

        public Repository(SchoolManagementContext context)
        {
            this._context = context;
        }

        public virtual async Task<TEntity> Create(TEntity model)
        {
            _context.Add(model);
            await _context.SaveChangesAsync();

            return model;
        }

        public virtual async Task<TEntity> Update(TEntity model)
        {
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return model;
        }

        public void Dispose()
        {
            try
            {
                if (_context != null)
                    _context.Dispose();

                GC.SuppressFinalize(this);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

}
