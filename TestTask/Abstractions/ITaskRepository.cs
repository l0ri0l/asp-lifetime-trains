using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestTask.Abstractions
{
    //Можно было бы обойтись без generic, но в дальнейшем это можно универсализировать
    public interface ITaskRepository<T>
    {
        public IEnumerable<T> FindAll();
        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);
        public Task<T> FindOne(Guid id);
        public Task Create(T entity);
        public void Update(T entity);
        public void Delete(T entity);
        public Task AddOrUpdate(T entity);
    }
}
