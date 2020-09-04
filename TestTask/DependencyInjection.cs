using Microsoft.Extensions.DependencyInjection;
using TestTask.DataBaseElements;
using TestTask.Abstractions;
using TestTask.Services;

namespace TestTask
{
    public class DependencyInjection
    {
        public static void BundleConfigurations(IServiceCollection service)
        {   
            //Создание объекта в начале каждого запроса
            service.AddScoped<ITaskRepository<TaskEntity>, TaskRepository>();
            service.AddScoped<ITaskDataBaseReadService, TaskDataBaseReadService>();
            service.AddScoped<ITaskDataBaseWriteService, TaskDataBaseWriteService>();
        }
    }
}
