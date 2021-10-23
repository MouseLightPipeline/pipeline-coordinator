using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MouseLight.Core.Data;
using MouseLight.Core.Model;

namespace MouseLight.Core.Service
{
    public class TaskExecutionConnectorService
    {
        private readonly IDictionary<Guid, TaskExecutionService> _serviceStageMap;

        private readonly IDictionary<Guid, TaskExecutionService> _serviceProjectMap;

        private readonly PipelineContextOptions _contextOptions;

        public TaskExecutionConnectorService(IOptions<PipelineContextOptions> contextOptions)
        {
            _contextOptions = contextOptions.Value;

            _serviceStageMap = new Dictionary<Guid, TaskExecutionService>();

            _serviceProjectMap = new Dictionary<Guid, TaskExecutionService>();
        }

        public ValueTask<TaskExecutionService> ForStage(Guid stageId)
        {
            if (_serviceStageMap.ContainsKey(stageId))
            {
                return ValueTask.FromResult(_serviceStageMap[stageId]);
            }

            using var db = new PipelineContext(_contextOptions);

            var projectService = new ProjectService(db);

            if (projectService.ProjectIdForStage(stageId) is Guid projectId)
            {
                var options = _contextOptions.CloneWithDatabaseName(projectId.ToString());

                var service = new TaskExecutionService(options);

                _serviceStageMap.Add(stageId, service);

                return ValueTask.FromResult(service);
            }

            return ValueTask.FromResult<TaskExecutionService>(null);
        }

        public ValueTask<TaskExecutionService> ForProject(Guid projectId)
        {
            if (_serviceProjectMap.ContainsKey(projectId))
            {
                return ValueTask.FromResult(_serviceProjectMap[projectId]);
            }

            var options = _contextOptions.CloneWithDatabaseName(projectId.ToString());

            var service = new TaskExecutionService(options);

            _serviceProjectMap.Add(projectId, service);

            return ValueTask.FromResult(service);
        }

        public void Drop(Guid projectId)
        {
            if (_serviceProjectMap.ContainsKey(projectId))
            {
                _serviceProjectMap.Remove(projectId);
            }

            using var db = new PipelineContext(_contextOptions);

            db.Database.EnsureDeleted();
        }
    }
}
