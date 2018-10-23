using CustomOrderSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CustomOrderSystem.Reository.Base
{
    public interface IRepository<T> where T : class
    {

        T GetSingleBy(Expression<Func<T, bool>> filter = null);
        void DeleteById(object id);
        void Delete(T item);
        T Insert(T item);
        T Update(T item);
        IEnumerable<T> GetAll();
        T GetById(object id);
        IEnumerable<T> GetBy(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
    }
}
