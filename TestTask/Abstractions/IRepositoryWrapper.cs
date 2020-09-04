using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.DataBaseElements;

namespace TestTask.Abstractions
{
    public interface IRepositoryWrapper
    {
        ITaskRepository<TaskEntity> Tasks { get; }
    }
}
