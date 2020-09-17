using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestTask.Abstractions;

namespace TestTask.DataBaseElements
{
    public class TaskRepository : ITaskRepository<TaskEntity>
    {
        private readonly TaskContext context;

        public TaskRepository(TaskContext db)
        {
            context = db;
        }

        public IEnumerable<TaskEntity> FindAll()
        {
            
                return context.Set<TaskEntity>().AsNoTracking().ToList();
        }
        public IEnumerable<TaskEntity> FindByCondition(Expression<Func<TaskEntity, bool>> expression)
        {
            
                return context.Set<TaskEntity>().Where(expression).AsNoTracking().ToList();
        }

        public async Task<TaskEntity> FindOne(Guid id)
        {
           
                return await context.Set<TaskEntity>().FindAsync(id);
        }
        public async Task Create(TaskEntity entity)
        { 
            
                context.Set<TaskEntity>().Add(entity);
                await context.SaveChangesAsync();

        }
        public void Update(TaskEntity entity)
        {
            
                context.Set<TaskEntity>().Update(entity);
                context.SaveChangesAsync();

        }

        public async Task AddOrUpdate(TaskEntity entity)
        {
            
                var taskEnt = await FindOne(entity.Id);
                if (taskEnt == null)
                    context.Set<TaskEntity>().Add(entity);
                else
                    context.Set<TaskEntity>().Update(entity);

                await context.SaveChangesAsync();

            
        }

        public void Delete(TaskEntity entity)
        {
           
                context.Set<TaskEntity>().Remove(entity);
                context.SaveChangesAsync();
            
        }
    }
}
