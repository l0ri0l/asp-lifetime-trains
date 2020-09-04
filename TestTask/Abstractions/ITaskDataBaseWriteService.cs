using TestTask.Models;

namespace TestTask.Abstractions
{
    public interface ITaskDataBaseWriteService
    {
        public TaskModel CreateTask();

        public void UpdateTask(TaskModel taskModel);
    }
}
