using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using MouseLight.Core.Data;

namespace MouseLight.Core.Service
{
    public class TaskExecutionConnectorService
    {
        private readonly IDictionary<Guid, TaskExecutionService> _serviceMap;

        private readonly PipelineContextOptions _contextOptions;

        public TaskExecutionConnectorService(PipelineContextOptions contextOptions)
        {
            _contextOptions = contextOptions;

            _serviceMap = new Dictionary<Guid, TaskExecutionService>();
        }

        public ValueTask<TaskExecutionService> ForStage(Guid stageId)
        {
            if (_serviceMap.ContainsKey(stageId))
            {
                return ValueTask.FromResult(_serviceMap[stageId]);
            }

            using var db = new PipelineContext(_contextOptions);

            var projectService = new ProjectService(db);

            if (projectService.ProjectIdForStage(stageId) is Guid projectId)
            {
                var options = _contextOptions.CloneWithDatabaseName(projectId.ToString());

                var service = new TaskExecutionService(options);

                _serviceMap.Add(stageId, service);

                return ValueTask.FromResult(service);
            }

            return ValueTask.FromResult<TaskExecutionService>(null);
        }
    }
}
