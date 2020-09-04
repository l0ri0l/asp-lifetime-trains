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
        private IRepositoryWrapper _repoWrapper;

        public TaskDataBaseWriteService(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
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

            _repoWrapper.Tasks.Create(taskEntity);
           // _repoWrapper.Save();

            return taskModel; 

            
        }

        public async void UpdateTask(TaskModel taskModel)
        {
            taskModel.Status = TaskState.running;
            taskModel.TimeStamp = DateTime.Now;

            var taskEntity = await _repoWrapper.Tasks.FindOne(taskModel.Id);
                SinchronaizeModelAndEntity(taskModel, taskEntity, _repoWrapper.Tasks);

                await Task.Delay(1000 * 60 * 2);

                taskModel.TimeStamp = DateTime.Now;
                taskModel.Status = TaskState.finished;

                SinchronaizeModelAndEntity(taskModel, taskEntity, _repoWrapper.Tasks);
        }

        private void SinchronaizeModelAndEntity(TaskModel taskModel, TaskEntity taskEntity, ITaskRepository<TaskEntity> repository) 
        {
            taskEntity.Status = taskModel.Status;
            taskEntity.TimeStamp = taskModel.TimeStamp;

            _repoWrapper.Tasks.Update(taskEntity);
          //  _repoWrapper.Save();
        }
    }

}
