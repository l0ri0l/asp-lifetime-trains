using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Enums;

namespace TestTask.Entities
{
    public class TaskEntity
    {
        public Guid Id { get; set; }

        public DateTime LastTimeActive { get; set; }

        public TasksStatus Status { get; set; }
    }
}
