using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Hydro.Data.Repositories
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<TEntity> _set;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _set = context.Set<TEntity>();
        }
        
        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>>? filter = null,
            IEnumerable<string>? includeProperties = null)
        {
            IQueryable<TEntity> query = _set;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var property in includeProperties)
                {
                    query = query.Include(property);
                }
            }

            return query.ToList();
        }

        public virtual TEntity? GetById(long id)
        {
            return _set.Find(id);
        }

        public virtual void Add(TEntity entity)
        {
            _set.Add(entity);
        }

        public virtual void Remove(TEntity entity)
        {
            _set.Remove(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _set.Update(entity);
        }

        public EntityEntry<TEntity> Entry(TEntity entity)
        {
            return _context.Entry(entity);
        }
    }
}
