using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using MouseLight.Coordinator.MessageQueue.TaskUpdate;
using MouseLight.Core.Data;
using MouseLight.Core.Service;
using MouseLight.UpdateMonitor.Service;

namespace MouseLight.UpdateMonitor
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<PipelineContextOptions>(Configuration.GetSection(PipelineContextOptions.PipelineContext));

            services.AddControllers();

            services.AddDbContext<PipelineContext>((serviceProvider, options) => options.UseNpgsql(serviceProvider.GetService<PipelineContextConnection>().ConnectionString));

            services.AddSingleton<PipelineContextConnection>();

            services.AddScoped<ProjectService>();

            services.AddSingleton<TaskUpdateMessageQueueMonitor>((serviceProvider) =>
            {
                return new TaskUpdateMessageQueueMonitor(serviceProvider.GetRequiredService<TaskUpdateWorkQueue>(), serviceProvider.GetRequiredService<IHostApplicationLifetime>().ApplicationStopping, serviceProvider.GetService<ILogger<TaskUpdateMessageQueueMonitor>>());
            });

            services.AddSingleton<TaskUpdateWorkQueue>();

            services.AddHostedService<TaskUpdateMessageService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
