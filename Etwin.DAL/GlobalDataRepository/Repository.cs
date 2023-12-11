using Etwin.Model;
using Etwin.DAL.GlobalDataRepository.IRepository;
using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Etwin.Model.Context;
using System.Threading.Tasks;

namespace Etwin.DAL.GlobalDataRepository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly GlobalDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(GlobalDbContext db)
        {
            this._db = db;
            this.dbSet = _db.Set<T>();
        }

        public void Add(T entity)
        {
            this.dbSet.Add(entity);
        }

        public T Get(int id)
        {
            return this.dbSet.Find(id);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedEnumerable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = this.dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }

            return query.ToList();
        }

        public IEnumerable<T> GetViewAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedEnumerable<T>> orderBy = null)
        {
            IQueryable<T> query = this.dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }

            return query.ToList();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = this.dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await query.ToListAsync();
        }


        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = this.dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }


            return query.FirstOrDefault();
        }

        public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
       
            IQueryable<T> query = this.dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }


            return await query.FirstOrDefaultAsync();
        }

        public void Remove(int id)
        {
            T entity = this.dbSet.Find(id);
            this.dbSet.Remove(entity);
        }

        public void Remove(T entity)
        {
            this.dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            this.dbSet.RemoveRange(entity);
        }
    }
}
