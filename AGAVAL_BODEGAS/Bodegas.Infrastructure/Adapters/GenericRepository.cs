using Bodegas.Domain.Entities;
using Bodegas.Domain.Ports;
using Bodegas.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;
using Z.EntityFramework.Plus;

namespace Bodegas.Infrastructure.Adapters
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DbSet<T> _entityBase;
        private readonly PrivadaDbContext _context;

        public GenericRepository(PrivadaDbContext context)
        {
            _context = context;
            _entityBase = _context.Set<T>();
        }

        public async Task<T> Get(Expression<Func<T, bool>> condition, string include="")
        {
            IQueryable<T> Query = _context.Set<T>();
            foreach (var includeProperty in include.Split
                (new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                Query = Query.Include(includeProperty);
            }
            if (condition != null) Query = Query.Where(condition);
            return await Query.AsNoTracking().FirstAsync();
        }

        public IQueryable<T> List(string include = "")
        {
            IQueryable<T> Query = _context.Set<T>();

            foreach (var includeProperty in include.Split
                (new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                Query = Query.Include(includeProperty);
            }

            return Query;
        }

        public async Task AddAsync(T entity)
        {
            if (entity == null) return;
            await _entityBase.AddAsync(entity);
            await CommitAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity == null) return;

            T patch = await _entityBase.AsNoTracking().Where(x => x.Equals(entity)).SingleAsync();

            var properties = entity.GetType().GetProperties().Select(x => new { 
                x.Name,
                Atributos = x.CustomAttributes.Select(x => x.AttributeType.Name).ToList()
            }).Where(x => x.Atributos.Contains("UpgradeableAttribute")).ToList();

            foreach (var property in properties)
            {
                PropertyInfo? entityPropertyInfo = patch.GetType().GetProperty(property.Name);
                PropertyInfo? patchPropertyInfo = entity.GetType().GetProperty(property.Name);
                if (entityPropertyInfo != null && patchPropertyInfo != null)
                {
                    entityPropertyInfo.SetValue(patch, patchPropertyInfo.GetValue(entity));
                }
            }
            _entityBase.Update(patch);
            await CommitAsync();
        }

        public async Task CommitAsync()
        {
            await _context.CommitAsync().ConfigureAwait(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            this._context.Dispose();
        }
    }
}
