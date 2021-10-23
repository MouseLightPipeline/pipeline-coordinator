using System;
using System.Linq;

using MouseLight.Core.Data;
using MouseLight.Core.Data.Activity;
using MouseLight.Core.Model.Activity;
using MouseLight.Core.Model.Activity.Message;

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

        public void Create(TaskExecution execution)
        {
            using var db = new ProjectActivityDbContext(_contextOptions);

            db.TaskExecution.Update(execution);

            db.SaveChanges();
        }

        public void ProcessUpdate(TaskExecutionUpdateMessage taskExecutionUpdate)
        {
            using var db = new ProjectActivityDbContext(_contextOptions);

            var taskExecution = db.TaskExecution.FirstOrDefault(t => t.Id == taskExecutionUpdate.Id);

            if (taskExecution == null)
            {
                taskExecution = new TaskExecution(taskExecutionUpdate);
            }
                        
        }
    }
}
