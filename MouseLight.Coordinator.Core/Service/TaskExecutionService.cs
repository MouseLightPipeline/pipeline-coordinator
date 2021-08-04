using System;

using MouseLight.Core.Data;
using MouseLight.Core.Data.Activity;
using MouseLight.Core.Model;

namespace MouseLight.Core.Service
{
    public class TaskExecutionService
    {
        private readonly PipelineContextOptions _contextOptions;

        public TaskExecutionService(PipelineContextOptions contextOptions)
        {
            _contextOptions = contextOptions;

            using var db = new ProjectActivityDbContext(_contextOptions);

            db.Database.EnsureCreated();
        }

        public void ProcessUpdate(TaskExecution taskExecution)
        {
            using var db = new ProjectActivityDbContext(_contextOptions);
                        
        }
    }
}
