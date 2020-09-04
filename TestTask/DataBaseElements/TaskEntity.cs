using System;
using System.ComponentModel.DataAnnotations;
using TestTask.Enums;

namespace TestTask.DataBaseElements
{
    // Сущность задачи
    public class TaskEntity
    {   
        [Key]
        public Guid Id { get; set; }

        public DateTime TimeStamp { get; set; }

        public TaskState Status { get; set; }
    }
}
