using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Abstractions;
using TestTask.DataBaseElements;

namespace TestTask.Services
{
    public class TaskRepository : IRepository<TaskEntity>
    {
        public void Add(TaskEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<TaskEntity> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TaskEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(TaskEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
