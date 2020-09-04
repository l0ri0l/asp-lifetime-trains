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
    // Дополнительные методы были добавлены для потенциального расширения и использования программы
    public class TaskDataBaseReadService : ITaskDataBaseReadService
    {
        private ITaskRepository<TaskEntity> _repo;

        public TaskDataBaseReadService(ITaskRepository<TaskEntity> repo)
        {
            _repo = repo;
        }

        public IEnumerable<TaskModel> FindInStatus(TaskState taskStatus) // поиск по статусу
        {
            var taskModels = _repo.FindByCondition(e => e.Status == taskStatus).Select(e => new TaskModel()
            {
                Id = e.Id,
                TimeStamp = e.TimeStamp,
                Status = e.Status
            });
            return taskModels;
        }

        public IEnumerable<TaskModel> FindInTime(DateTime? dateFrom, DateTime? dateTo) // поиск по времени
        {
            if (dateFrom == null && dateTo == null)
                return null;

            var taskEntities = _repo.FindByCondition(x => (x.TimeStamp > dateFrom.GetValueOrDefault(DateTime.MinValue))
                                                            && (x.TimeStamp < dateFrom.GetValueOrDefault(DateTime.MaxValue)))
            .Select(e => new TaskModel()
            {
                Id = e.Id,
                TimeStamp = e.TimeStamp,
                Status = e.Status
            });

            return taskEntities;

        }

        public async Task<TaskModel> FindTask(Guid id) // поиск одной задачи
        {            
           var taskEntity = await _repo.FindOne(id);
           if(taskEntity != null)
           {
                var taskModel = new TaskModel()
                {
                    Id = taskEntity.Id,
                    TimeStamp = taskEntity.TimeStamp,
                    Status = taskEntity.Status
                };
                return taskModel;
           }
           return null;
           
        }

        public IEnumerable<TaskModel> GetAll() // выборка всех из базы
        {
          var taskModels = _repo.FindAll().Select(e => new TaskModel()
          {
              Id = e.Id,
              TimeStamp = e.TimeStamp,
              Status = e.Status
          });
          return taskModels.ToList();
        }
    }
}
