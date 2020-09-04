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

        public TaskContext()
        {
           
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=db.Tasks;Trusted_Connection=True;MultipleActiveResultSets=true;");
        }
    }
}
