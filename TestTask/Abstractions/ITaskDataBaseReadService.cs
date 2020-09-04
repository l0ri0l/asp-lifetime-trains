using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.Enums;
using TestTask.Models;

namespace TestTask.Abstractions
{
    public interface ITaskDataBaseReadService
    {
        public Task<TaskModel> FindTask(Guid id);

        public IEnumerable<TaskModel> GetAll();

        public IEnumerable<TaskModel> FindInTime(DateTime? dateFrom, DateTime? dateTo);

        public IEnumerable<TaskModel> FindInStatus(TaskState taskStatus);
    }
}
