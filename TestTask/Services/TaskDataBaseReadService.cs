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
        private readonly IRepository<TaskEntity> _repository;


        public TaskDataBaseReadService(IRepository<TaskEntity> repository)
        {
            _repository = repository;
        }

        public IEnumerable<TaskModel> FindInStatus(TaskState taskStatus)
        {
            var taskModels = _repository.GetAll().Where(e => e.Status == taskStatus).Select(e => new TaskModel()
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

            var taskEntities = _repository.GetAll().Where(x => (x.TimeStamp > dateFrom.GetValueOrDefault(DateTime.MinValue))
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
           var taskEntity = _repository.Get(id);
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
          var taskModels = _repository.GetAll().Select(e => new TaskModel()
          {
              Id = e.Id,
              TimeStamp = e.TimeStamp,
              Status = e.Status
          });
          return taskModels.ToList();
        }
    }
}
