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
using Microsoft.Extensions.Options;

using MouseLight.Coordinator.MessageQueue.TaskUpdate;
using MouseLight.Core.Data;
using MouseLight.Core.Data.Activity;
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

            services.AddSingleton<TaskExecutionConnectorService>();

            services.AddSingleton<TaskUpdateMessageQueueMonitor>((serviceProvider) =>
            {
                return new TaskUpdateMessageQueueMonitor(serviceProvider.GetRequiredService<TaskUpdateWorkQueue>(), serviceProvider.GetRequiredService<IHostApplicationLifetime>().ApplicationStopping, serviceProvider.GetService<ILogger<TaskUpdateMessageQueueMonitor>>());
            });

            services.AddSingleton<TaskUpdateWorkQueue>();

            services.AddHostedService<TaskUpdateMessageService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IOptions<PipelineContextOptions> contextOptions)
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

            /*
            var opts = contextOptions.Value;

            opts.Database = "f106e72c-a43e-4baf-a6f0-2395a22a65c6";

            using var db = new ProjectDbContext(opts);

            var set = db.Set<InProcessTile>("55c2a6d6-5c2b-4f42-81d9-45f81b4308f9_InProcesses");

            Debug.WriteLine("done");
            */
        }
    }
}
