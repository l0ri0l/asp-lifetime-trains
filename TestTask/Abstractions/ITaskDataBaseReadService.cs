using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.DataBaseElements;
using TestTask.Enums;
using TestTask.Models;

namespace TestTask.Abstractions
{
    public interface ITaskDataBaseReadService
    {
        public TaskModel FindTask(Guid id);

        public IEnumerable<TaskModel> GetAll();

        public IEnumerable<TaskModel> FindInTime(DateTime? dateFrom, DateTime? dateTo);

        public IEnumerable<TaskModel> FindInStatus(TaskState taskStatus);
    }
}
