using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelpDesk.Model.Entities.BaseEntities;

namespace HelpDesk.BLL.Repository.Abstracts
{
    public interface IRepository<T, TId> where T : BaseEntity<TId>
    {
        List<T> GetAll();
        List<T> GetAll(Func<T, bool> predicate);
        List<T> GetAll(params string[] includes);
        List<T> GetAll(Func<T, bool> predicate, params string[] includes);
        T GetById(TId id);
        int Insert(T entity);
        int Update(T entity);
        int Delete(T entity);
        int Save();
        IQueryable<T> Queryable();
        IQueryable<T> Queryable(Func<T, bool> predicate);
    }
}
