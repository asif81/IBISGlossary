using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class 
    {
        T Get(int Id);
        IEnumerable<T> GetAllOrSearch(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Expression<Func<T, bool>> filter = null);

        void Add(T entity);

        void Remove(int Id);

        void Remove(T entity);
    }
}
