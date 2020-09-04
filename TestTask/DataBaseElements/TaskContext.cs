using Microsoft.EntityFrameworkCore;

namespace TestTask.DataBaseElements
{
    public class TaskContext : DbContext
    {
        //Контекст
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
