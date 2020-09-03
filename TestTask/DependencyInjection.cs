using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using TestTask.DataBaseElements;
using TestTask.Abstractions;
using TestTask.Services;

namespace TestTask
{
    public class DependencyInjection
    {
        public static void BundleConfigurations(IServiceCollection service)
        {
            //service.AddSingleton<DbContext, TaskContext>();
            service.AddScoped<IRepository<TaskEntity>, TaskRepository>();
            service.AddScoped<ITaskDataBaseReadService, TaskDataBaseReadService>();
            service.AddScoped<ITaskDataBaseWriteService, TaskDataBaseWriteService>();
        }
    }
}
