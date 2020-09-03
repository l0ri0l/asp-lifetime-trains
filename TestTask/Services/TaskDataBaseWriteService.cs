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
    public class TaskDataBaseWriteService : ITaskDataBaseWriteService
    {
        private readonly IRepository<TaskEntity> _repository;

        public TaskDataBaseWriteService(IRepository<TaskEntity> repository)
        {
            _repository = repository;
        }

        public TaskModel CreateTask()
        {
            var id = Guid.NewGuid();
            var taskModel = new TaskModel(id);
                    
                var taskEntity = new TaskEntity()
                {
                    Id = taskModel.Id,
                    TimeStamp = taskModel.TimeStamp,
                    Status = taskModel.Status,
                };

                _repository.Add(taskEntity);
            

            return taskModel; 

            
        }

        public async void TestUpdateTask(TaskModel taskModel)
        {
            taskModel.Status = TaskState.running;
            taskModel.TimeStamp = DateTime.Now;

            var taskEntity = await _repository.Get(taskModel.Id);
                SinchronaizeModelAndEntity(taskModel, taskEntity, _repository);

                await Task.Delay(1000 * 60 * 2);

                taskModel.TimeStamp = DateTime.Now;
                taskModel.Status = TaskState.finished;

                SinchronaizeModelAndEntity(taskModel, taskEntity, _repository);
        }

        private void SinchronaizeModelAndEntity(TaskModel taskModel, TaskEntity taskEntity, IRepository<TaskEntity> repository) 
        {
            taskEntity.Status = taskModel.Status;
            taskEntity.TimeStamp = taskModel.TimeStamp;

            _repository.Update(taskEntity);
        }
    }

}
