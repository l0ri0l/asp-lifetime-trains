using Microsoft.EntityFrameworkCore;
using System;

namespace TestTask.DataBaseElements
{
    public class TaskContext : DbContext
    {
        //Контекст
        public DbSet<TaskEntity> Tasks { get; set; }

        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

    }
}

