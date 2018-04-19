﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace BootstrapWPFApplication.Core.Services
{
    public interface IService<TEntity> where TEntity : class
    {
        TEntity Find(params object[] keyValues);
        void Insert(TEntity entity);
        void InsertRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Delete(object id);
        void Delete(TEntity entity);
        IQueryable<TEntity> Queryable();
        IEnumerable<TEntity> List();
        IEnumerable<TEntity> List(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate);
    }
}
