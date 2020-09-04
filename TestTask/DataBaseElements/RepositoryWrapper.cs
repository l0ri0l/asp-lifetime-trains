using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Abstractions;

namespace TestTask.DataBaseElements
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private TaskContext _repoContext;
        private ITaskRepository<TaskEntity> _tasks;

        public ITaskRepository<TaskEntity> Tasks
        {
            get
            {
                if(_tasks == null)
                {
                    _tasks = new TaskRepository();
                }
                return _tasks;
            }
        }

        public RepositoryWrapper(TaskContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        
    }
}
