using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using MouseLight.Coordinator.MessageQueue.TaskUpdate;

namespace MouseLight.UpdateMonitor.Service
{
    public class TaskUpdateMessageService : BackgroundService
    {
        public TaskUpdateWorkQueue TaskQueue { get; }

        private readonly ILogger _logger;

        public TaskUpdateMessageService(TaskUpdateWorkQueue queue, ILogger<TaskUpdateMessageService> logger)
        {
            TaskQueue = queue;

            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            var publisher = new TaskUpdatePublisher();

            publisher.Start();

            await ProcessMessagesAsync(cancellationToken);
        }

        private async Task ProcessMessagesAsync(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                var item = await TaskQueue.DequeueAsync(token);

                _logger.LogInformation("processing item");
            }
        }
    }
}
