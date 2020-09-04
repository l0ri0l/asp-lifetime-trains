using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestTask.Abstractions
{
    //Можно было бы обойтись без generic, но в дальнейшем это можно универсализировать
    public interface ITaskRepository<T>
    {
        public IQueryable<T> FindAll();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        public Task<T> FindOne(Guid id);
        public void Create(T entity);
        public void Update(T entity);
        public void Delete(T entity);
        public void AddOrUpdate(T entity);
    }
}
