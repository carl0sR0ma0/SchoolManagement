using System;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<TEntity> Create(TEntity model);
    }
}
