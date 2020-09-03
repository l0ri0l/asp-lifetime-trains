using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask.Abstractions
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        Task<T> Get(Guid id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        void Dispose();
        void Save();
    }
}
