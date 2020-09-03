using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Models;

namespace TestTask.Abstractions
{
    public interface ITaskDataBaseWriteService
    {
        public TaskModel CreateTask();

        public void TestUpdateTask(TaskModel taskModel);
    }
}
