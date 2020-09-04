using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.DataBaseElements;
using TestTask.Enums;
using TestTask.Models;

namespace TestTask.Abstractions
{
    public interface ITaskDataBaseWriteService
    {
        public TaskModel CreateTask();

        public void UpdateTask(TaskModel taskModel);
    }
}
