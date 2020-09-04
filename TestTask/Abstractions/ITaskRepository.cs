using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestTask.Abstractions
{
    public interface ITaskRepository<T>
    {
        public IQueryable<T> FindAll();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        public Task<T> FindOne(Guid id);
        public void Create(T entity);
        public void Update(T entity);
        public void Delete(T entity);
    }
}
