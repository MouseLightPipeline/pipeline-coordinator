using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using MouseLight.Coordinator.MessageQueue.TaskUpdate;
using MouseLight.Core.Service;

namespace MouseLight.UpdateMonitor.Service
{
    public class TaskUpdateMessageService : BackgroundService
    {
        public TaskUpdateWorkQueue TaskQueue { get; }

        private readonly TaskExecutionConnectorService _taskExecutionConnector;

        private readonly ILogger _logger;

        public TaskUpdateMessageService(TaskUpdateWorkQueue queue, TaskExecutionConnectorService taskExecutionConnector, ILogger<TaskUpdateMessageService> logger)
        {
            TaskQueue = queue;

            _taskExecutionConnector = taskExecutionConnector;

            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            var publisher = new TaskUpdatePublisher();

            publisher.Start(cancellationToken);

            await ProcessMessagesAsync(cancellationToken);
        }

        private async Task ProcessMessagesAsync(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                var item = await TaskQueue.DequeueAsync(token);

                var service = await _taskExecutionConnector.ForProject(item.ProjectId);

                service?.ProcessUpdate(item);

                _logger.LogInformation("processeditem");
            }

            _logger?.LogInformation("process message cancelled");
        }
    }
}
