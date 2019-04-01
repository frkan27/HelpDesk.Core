using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelpDesk.DAL;
using HelpDesk.Model.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.BLL.Repository.Abstracts
{
    public abstract class RepoBase<T, TId> : IRepository<T, TId> where T : BaseEntity<TId>
    {

        private readonly MyContext DbContext;
        private readonly DbSet<T> DbObject;

        internal RepoBase(MyContext dbContext)
        {
            DbContext = dbContext;
            DbObject = DbContext.Set<T>();
        }
        public List<T> GetAll()
        {
            return DbObject.ToList();
        }

        public List<T> GetAll(Func<T, bool> predicate)
        {
            return DbObject.Where(predicate).ToList();
        }

        public List<T> GetAll(params string[] includes)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll(Func<T, bool> predicate, params string[] includes)
        {
            throw new NotImplementedException();
        }

        public T GetById(TId id)
        {
            return DbObject.Find(id);
        }

        public int Insert(T entity)
        {
            DbObject.Add(entity);
            return DbContext.SaveChanges();
             
        }
        public int Delete(T entity)
        {
            DbObject.Remove(entity);
            return DbContext.SaveChanges();
        }

        public int Update(T entity)
        {
            DbObject.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
            return DbContext.SaveChanges();
        }

        public int Save()
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Queryable()
        {
            return DbObject.AsQueryable();
        }

        public IQueryable<T> Queryable(Func<T, bool> predicate)
        {
            return DbObject.Where(predicate).AsQueryable();
        }

        IQueryable<T> IRepository<T, TId>.Queryable()
        {
            throw new NotImplementedException();
        }

        IQueryable<T> IRepository<T, TId>.Queryable(Func<T, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
