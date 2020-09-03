using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Abstractions;

namespace TestTask.DataBaseElements
{
    public class TaskRepository : IRepository<TaskEntity>
    {
        private readonly TaskContext _db;

        public TaskRepository(TaskContext db)
        {
            _db = db;
        }

        public void Add(TaskEntity task)
        {
            _db.Tasks.Add(task);
        }

        public void Delete(Guid id)
        {
            TaskEntity task = _db.Tasks.Find(id);
            if (task != null)
                _db.Tasks.Remove(task);
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<TaskEntity> Get(Guid id)
        {
            return await _db.Tasks.FindAsync(id);
        }

        public IEnumerable<TaskEntity> GetAll()
        {
            return _db.Tasks;
        }

        public void Update(TaskEntity task)
        {
            _db.Update(task);
            _db.Entry(task).State = EntityState.Modified;
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
