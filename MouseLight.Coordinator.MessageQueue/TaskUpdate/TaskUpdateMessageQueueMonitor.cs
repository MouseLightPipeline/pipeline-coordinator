using System;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using RabbitMQ.Client;
using RabbitMQ.Client.Events;

using MouseLight.Core.Model.Activity;
using MouseLight.Core.Model.Activity.Message;

namespace MouseLight.Coordinator.MessageQueue.TaskUpdate
{
    public class TaskUpdateMessageQueueMonitor
    {
        private readonly TaskUpdateWorkQueue _taskQueue;
        private readonly CancellationToken _cancellationToken;
        private readonly ILogger _logger;

        private IConnection _connection;
        private IModel _channel;
        private EventingBasicConsumer _consumer;

        public TaskUpdateMessageQueueMonitor(TaskUpdateWorkQueue taskQueue, CancellationToken token, ILogger<TaskUpdateMessageQueueMonitor> logger)
        {
            _taskQueue = taskQueue;
            _cancellationToken = token;
            _logger = logger;
        }

        public void Start()
        {
            Task.Run(async () => await Monitor());
        }

        private async Task Monitor()
        {
            try
            {
                var factory = new ConnectionFactory() { HostName = "127.0.0.1", Port = 6520 };

                _connection = factory.CreateConnection();

                _channel = _connection.CreateModel();

                _channel.QueueDeclare(queue: "TaskExecutionUpdateQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);

                _channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

                _consumer = new EventingBasicConsumer(_channel);

                _consumer.Received += async (model, args) =>
                {
                    var taskExecution = JsonSerializer.Deserialize<TaskExecutionUpdateMessage>(Encoding.UTF8.GetString(args.Body.ToArray()));

                    await _taskQueue.EnqueueAsync(taskExecution);

                    _channel.BasicAck(deliveryTag: args.DeliveryTag, multiple: false);
                };

                _channel.BasicConsume(queue: "TaskExecutionUpdateQueue", autoAck: false, consumer: _consumer);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "failed to configure receive channel");
            }

            while (!_cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(int.MaxValue, _cancellationToken);
            }
        }
    }
}
