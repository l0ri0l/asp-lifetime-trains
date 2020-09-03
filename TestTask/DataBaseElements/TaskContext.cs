using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask.DataBaseElements
{
    public class TaskContext : DbContext
    {
        public DbSet<TaskEntity> Tasks { get; set; }

        public TaskContext(DbContextOptions<TaskContext> options)
           : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
