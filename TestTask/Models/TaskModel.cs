using System;
using TestTask.Enums;

namespace TestTask.Models
{
    public class TaskModel
    {
        // Модель задачи
        public Guid Id { get; set; }

        public DateTime TimeStamp { get; set; }

        public TaskState Status { get; set; }

        public TaskModel(Guid guid) 
        {
            Id = guid;
            TimeStamp = DateTime.Now;
            Status = TaskState.created;
        }

        public TaskModel()
        {

        }
    }
}
