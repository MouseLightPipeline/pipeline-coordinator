using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MouseLight.Coordinator.MessageQueue.TaskUpdate
{
    public class TaskUpdateMessageQueueMonitor
    {
        private readonly TaskUpdateWorkQueue _taskQueue;
        private readonly CancellationToken _cancellationToken;

        private EventingBasicConsumer _consumer;

        public TaskUpdateMessageQueueMonitor(TaskUpdateWorkQueue taskQueue, CancellationToken token, ILogger<TaskUpdateMessageQueueMonitor> logger)
        {
            _taskQueue = taskQueue;
            _cancellationToken = token;
        }

        public void Start()
        {
            Task.Run(async () => await Monitor());
        }

        private async Task Monitor()
        {
            var factory = new ConnectionFactory() { HostName = "127.0.0.1", Port = 6520 };

            using var connection = factory.CreateConnection();

            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "TaskExecutionUpdateQueue", durable: false, exclusive: false);

            _consumer = new EventingBasicConsumer(channel);

            _consumer.Received += async (model, args) =>
            {
                await _taskQueue.EnqueueAsync(new TaskUpdateWorkItem());
            };

            channel.BasicConsume(queue: "TaskExecutionUpdateQueue", autoAck: true, consumer: _consumer);


            while (!_cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(60000, _cancellationToken);
            }

        }
    }
}
