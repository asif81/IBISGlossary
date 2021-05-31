using DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext db;
        internal DbSet<T> dbSet;

        public Repository(DbContext dbContext)
        {
            db = dbContext;
            this.dbSet = dbContext.Set<T>();
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(int Id)
        {
            return dbSet.Find(Id);
        }

        public IEnumerable<T> GetAllOrSearch(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                return query.Where(filter).ToList();
            }

            return query.ToList();
        }

        public void Remove(int Id)
        {
            T entityToRemove = dbSet.Find(Id);
            dbSet.Remove(entityToRemove);
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }
    }
}
