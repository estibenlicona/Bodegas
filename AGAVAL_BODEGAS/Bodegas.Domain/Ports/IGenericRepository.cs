using Bodegas.Domain.Entities;
using System.Linq.Expressions;

namespace Bodegas.Domain.Ports
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IQueryable<T> List(string includes = "");

        Task<T> Get(Expression<Func<T, bool>> condition, string includes = "");

        Task AddAsync(T entity);

        Task UpdateAsync(T entity);
    }
}