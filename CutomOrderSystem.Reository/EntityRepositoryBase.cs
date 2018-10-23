using CustomOrderSystem.Entity;
using CustomOrderSystem.Reository.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace CustomOrderSystem.Repository
{
    public abstract class EntityRepositoryBase<T>: IRepository<T> where T : class

    {
        protected DbSet<T> _dbSet { get; set; }
        protected CusDataContext _dataContext { get; private set; }
        public EntityRepositoryBase()
        {

            this._dataContext = new CusDataContext();
            this._dbSet = _dataContext.Set<T>();
        }

        private IQueryable<T> ApplyFilter(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = _dbSet;
            return filter == null ? query : query.Where(filter);
        }

        public void Delete(T item)
        {
            _dbSet.Remove(item);
            _dataContext.SaveChanges();
        }

        public void DeleteById(object id)
        {
            T entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }

        public T Insert(T item)
        {
            _dbSet.Add(item);
            
            _dataContext.SaveChanges();
            return item;
        }

        public T Update(T item)
        {
            _dbSet.AddOrUpdate(item);
          
            _dataContext.SaveChanges();
            return item;
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.AsEnumerable();
        }

        public T GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> GetBy(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = ApplyFilter(filter);
            return orderBy != null ? orderBy(query).ToList() : query.ToList();
        }

        public T GetSingleBy(Expression<Func<T, bool>> filter = null)
        {
            return filter != null ? _dbSet.FirstOrDefault(filter) : _dbSet.FirstOrDefault();
        }

       
    }
}
