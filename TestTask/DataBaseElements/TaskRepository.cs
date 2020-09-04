using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestTask.Abstractions;
using TestTask.DataBaseElements;

namespace TestTask.DataBaseElements
{
    public class TaskRepository : ITaskRepository<TaskEntity>
    {
        
        public TaskRepository()
        {
           
        }
        public IQueryable<TaskEntity> FindAll()
        {
            using (var context = new TaskContext())
                return context.Set<TaskEntity>().AsNoTracking();
        }
        public IQueryable<TaskEntity> FindByCondition(Expression<Func<TaskEntity, bool>> expression)
        {
            using (var context = new TaskContext())
                return context.Set<TaskEntity>().Where(expression).AsNoTracking();
        }

        public async Task<TaskEntity> FindOne(Guid id)
        {
            using (var context = new TaskContext())
                return await context.Set<TaskEntity>().FindAsync(id);
        }
        public void Create(TaskEntity entity)
        { 
            using (var context = new TaskContext())
            {
                context.Set<TaskEntity>().Add(entity);
                context.SaveChanges();
            }
        }
        public void Update(TaskEntity entity)
        {
            using (var context = new TaskContext())
            {
                context.Set<TaskEntity>().Update(entity);
                context.SaveChanges();
            }
        }
        public void Delete(TaskEntity entity)
        {
            using (var context = new TaskContext())
            {
                context.Set<TaskEntity>().Remove(entity);
                context.SaveChanges();
            }
        }
    }
}
