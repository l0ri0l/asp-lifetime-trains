using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TestTask.Abstractions;
using TestTask.DataBaseElements;
using TestTask.Services;

namespace TestTask
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<TaskContext>(options =>
            options.UseSqlServer(connection, sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure();
                }), ServiceLifetime.Singleton); // ставим так потому что дефолтное значение Scoped и нам нужно использовать один и тот же контекст в рамках одного запроса в течении двух минут минимум
            services.AddSingleton<ITaskRepository<TaskEntity>, TaskRepository>();
            services.AddScoped<ITaskDataBaseReadService, TaskDataBaseReadService>();
            services.AddScoped<ITaskDataBaseWriteService, TaskDataBaseWriteService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
