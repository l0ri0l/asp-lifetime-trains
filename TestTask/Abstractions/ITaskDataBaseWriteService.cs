using System.Threading.Tasks;
using TestTask.Models;

namespace TestTask.Abstractions
{
    public interface ITaskDataBaseWriteService
    {
        public Task<TaskModel> CreateTask();

        public Task UpdateTask(TaskModel taskModel);
    }
}
