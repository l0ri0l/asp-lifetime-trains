using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Abstractions;
using TestTask.DataBaseElements;
using TestTask.Enums;
using TestTask.Models;

namespace TestTask.Services
{
    public class TaskDataBaseReadService : ITaskDataBaseReadService
    {
        private IRepositoryWrapper _repoWrapper;

        public TaskDataBaseReadService(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public IEnumerable<TaskModel> FindInStatus(TaskState taskStatus)
        {
            var taskModels = _repoWrapper.Tasks.FindByCondition(e => e.Status == taskStatus).Select(e => new TaskModel()
            {
                Id = e.Id,
                TimeStamp = e.TimeStamp,
                Status = e.Status
            });
            return taskModels;
        }

        public IEnumerable<TaskModel> FindInTime(DateTime? dateFrom, DateTime? dateTo)
        {
            if (dateFrom == null && dateTo == null)
                return null;

            var taskEntities = _repoWrapper.Tasks.FindByCondition(x => (x.TimeStamp > dateFrom.GetValueOrDefault(DateTime.MinValue))
                                                            && (x.TimeStamp < dateFrom.GetValueOrDefault(DateTime.MaxValue)))
            .Select(e => new TaskModel()
            {
                Id = e.Id,
                TimeStamp = e.TimeStamp,
                Status = e.Status
            });

            return taskEntities;

        }

        public TaskModel FindTask(Guid id)
        {            
           var taskEntity = _repoWrapper.Tasks.FindOne(id);
           if(taskEntity.Result != null)
           {
                var taskModel = new TaskModel()
                {
                    Id = taskEntity.Result.Id,
                    TimeStamp = taskEntity.Result.TimeStamp,
                    Status = taskEntity.Result.Status
                };
                return taskModel;
           }
           return null;
           
        }

        public IEnumerable<TaskModel> GetAll()
        {
          var taskModels = _repoWrapper.Tasks.FindAll().Select(e => new TaskModel()
          {
              Id = e.Id,
              TimeStamp = e.TimeStamp,
              Status = e.Status
          });
          return taskModels.ToList();
        }
    }
}
