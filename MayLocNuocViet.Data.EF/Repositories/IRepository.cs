using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace  Fsoft.SKU.CoreApp.Data.EF.Repositories
{
    public interface IRepository<T> where T : class
    {
        //T FindById(object id, params Expression<Func<T, object>>[] includeProperties);

        T FindSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> FindAll(params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> FindAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);


        IQueryable<T> GetMany(Expression<Func<T, bool>> where);

        void Insert(T entity);

        void Update(T entity);

        void Remove(T entity);

        void Remove(object id);

        IQueryable<T> GetAll();

        T Get(Expression<Func<T, bool>> where);

        T GetById(object id);

        void RemoveMultiple(List<T> entities);
    }
}
