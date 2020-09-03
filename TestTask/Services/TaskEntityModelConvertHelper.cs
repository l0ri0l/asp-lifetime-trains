using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Abstractions;
using TestTask.DataBaseElements;
using TestTask.Models;

namespace TestTask.Services
{
    public class TaskEntityModelConvertHelper : ITaskEntityModelConvertHelper
    {
        public TaskModel ConvertFromEntityToModel(TaskEntity taskEntity)
        {
            TaskModel taskModel = new TaskModel()
            {
                Id = taskEntity.Id,
                TimeStamp = taskEntity.TimeStamp,
                Status = taskEntity.Status
            };
            return taskModel;
        }

        public TaskEntity ConvertFromModelToEntity(TaskModel taskModel)
        {
            TaskEntity taskEntity = new TaskEntity()
            {
                Id = taskModel.Id,
                TimeStamp = taskModel.TimeStamp,
                Status = taskModel.Status
            };
            return taskEntity;
        }
    }
}
