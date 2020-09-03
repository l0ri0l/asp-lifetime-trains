using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Enums;

namespace TestTask.Models
{
    public class TaskModel
    {
        public Guid Id { get; set; }

        public DateTime LastTimeActive { get; set; }

        public TasksStatus Status { get; set; }

        public void Run()
        {

        }
    }
}
