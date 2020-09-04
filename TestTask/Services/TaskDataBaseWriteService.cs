using System;
using System.Threading.Tasks;
using TestTask.Abstractions;
using TestTask.DataBaseElements;
using TestTask.Enums;
using TestTask.Models;

namespace TestTask.Services
{
    public class TaskDataBaseWriteService : ITaskDataBaseWriteService
    {
        private ITaskRepository<TaskEntity> _repo;

        public TaskDataBaseWriteService(ITaskRepository<TaskEntity> repo)
        {
            _repo = repo;
        }

        public TaskModel CreateTask() // создание задачи
        {
            var id = Guid.NewGuid();
            var taskModel = new TaskModel(id);
                    
                var taskEntity = new TaskEntity()
                {
                    Id = taskModel.Id,
                    TimeStamp = taskModel.TimeStamp,
                    Status = taskModel.Status,
                };

            _repo.Create(taskEntity);
           

            return taskModel; 

            
        }

        //этот метод можно было бы вынести в TaskModel в метод RunTask() или в отдельный сервис TaskRunner
        //но так как по сути выполняется только перезапись в БД, оставим его здесь

        public async void UpdateTask(TaskModel taskModel) {
            try
            {
                taskModel.Status = TaskState.running;
                taskModel.TimeStamp = DateTime.Now;

                var taskEntity = await _repo.FindOne(taskModel.Id);
                SinchronaizeModelAndEntity(taskModel, taskEntity);

                await Task.Delay(1000 * 60 * 2);

                taskModel.TimeStamp = DateTime.Now;
                taskModel.Status = TaskState.finished;

                SinchronaizeModelAndEntity(taskModel, taskEntity);
            }
            catch (Exception ex)
            {
                taskModel.Status = TaskState.crashed;
                var taskEnt = new TaskEntity()
                {
                    Id = taskModel.Id,
                    TimeStamp = taskModel.TimeStamp,
                    Status = taskModel.Status
                };
                _repo.AddOrUpdate(taskEnt);
            }
        }

        private void SinchronaizeModelAndEntity(TaskModel taskModel, TaskEntity taskEntity) 
        {
            taskEntity.Status = taskModel.Status;
            taskEntity.TimeStamp = taskModel.TimeStamp;

            _repo.Update(taskEntity);
        }
    }

}
