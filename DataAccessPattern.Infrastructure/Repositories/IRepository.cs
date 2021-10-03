using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccessPattern.Infrastructure.Repositories
{
    public interface IRepository<T>
    {
        T Add(T entity);
        T Update(T entity);
        T Get(Guid id);
        IEnumerable<T> All();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);  // ex: Find(Customer => customer.Age > 20)
        void SaveChanges();

    }
}
