using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.DataBaseElements;
using TestTask.Models;

namespace TestTask.Abstractions
{
    public interface ITaskEntityModelConvertHelper
    {
        public TaskEntity ConvertFromModelToEntity(TaskModel taskModel);
        public TaskModel ConvertFromEntityToModel(TaskEntity taskEntity);
    }
}
