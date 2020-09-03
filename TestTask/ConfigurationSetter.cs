using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using TestTask.Entities;
using TestTask.Abstractions;
using TestTask.Services;

namespace TestTask
{
    public class ConfigurationSetter
    {
        public static void BundleConfigurations(IServiceCollection service, IConfiguration configuration)
        {
            string connection = configuration.GetConnectionString("DefaultConnection");
            service.AddDbContext<TaskContext>(options => options.UseSqlServer(connection));
            service.AddHttpContextAccessor();
            service.AddScoped<ITaskDataBaseReadService, TaskDataBaseReadService>();
            service.AddScoped<ITaskDataBaseWriteService, TaskDataBaseWriteService>();
        }
    }
}
