using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MLT.MayLocNuocViet.Infrastructure.Interfaces
{
    public interface IEFRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        TEntity Get(Expression<Func<TEntity, bool>> where);

        TEntity GetById(object id);

        TEntity FindSingle(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);

        IQueryable<TEntity> FindAll(params Expression<Func<TEntity, object>>[] includeProperties);

        IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);

        void InsertMultiple(List<TEntity> entities);

        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Remove(TEntity entity);

        void Remove(object id);

        void RemoveMultiple(List<TEntity> entities);
    }
}
