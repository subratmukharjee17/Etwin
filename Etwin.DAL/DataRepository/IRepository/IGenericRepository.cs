using Etwin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Etwin.DAL.DataRepository
{
    public interface IGenericRepository<T> where T : class
    {
        ICollection<TType> GetWithFilters<TType>(Expression<Func<T, bool>> where, Expression<Func<T, TType>> select) where TType : class;
        IEnumerable<T> GetAll();
        IQueryable<T> Table { get; }
        T GetById(object id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(object id);
        void Save();
        
    }
}
