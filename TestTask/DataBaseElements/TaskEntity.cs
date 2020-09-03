using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Enums;

namespace TestTask.DataBaseElements
{
    public class TaskEntity
    {   
        [Key]
        public Guid Id { get; set; }

        public DateTime TimeStamp { get; set; }

        public TaskState Status { get; set; }
    }
}
