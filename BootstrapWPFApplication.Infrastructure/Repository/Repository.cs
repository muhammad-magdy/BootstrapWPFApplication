using BootstrapWPFApplication.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BootstrapWPFApplication.Infrastructure.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _dbContext;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TEntity Find(params object[] keyValues)
        {
            return _dbContext.Set<TEntity>().Find(keyValues);
        }

        public virtual IEnumerable<TEntity> List()
        {
            return _dbContext.Set<TEntity>().AsEnumerable();
        }

        public virtual IEnumerable<TEntity> List(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>()
                   .Where(predicate)
                   .AsEnumerable();
        }

        public void Insert(TEntity entity)
        {
            Attach(entity);
            _dbContext.Set<TEntity>().Add(entity);
        }

        public void InsertRange(IEnumerable<TEntity> entities)
        {
            _dbContext.Set<TEntity>().AddRange(entities);
        }

        public void Update(TEntity entity)
        {
            Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            var dbset = _dbContext.Set<TEntity>();
            var entry = _dbContext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                Attach(entity);
            }
            dbset.Remove(entity);
        }

        public void Delete(object id)
        {
            var entity = _dbContext.Set<TEntity>().Find(id);
            Delete(entity);
        }

        public IQueryable<TEntity> Queryable()
        {
            return _dbContext.Set<TEntity>();
        }

        private void Attach(TEntity entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached)
            {
                _dbContext.Set<TEntity>().Attach(entity);
            }
        }
    }
}
