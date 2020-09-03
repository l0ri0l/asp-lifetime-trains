using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.DataBaseElements;
using TestTask.Enums;
using TestTask.Services;

namespace TestTask.Models
{
    public class TaskModel
    {
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
