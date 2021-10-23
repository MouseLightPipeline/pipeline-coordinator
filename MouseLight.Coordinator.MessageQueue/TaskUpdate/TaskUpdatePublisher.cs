using System;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

using RabbitMQ.Client;

using MouseLight.Core.Model.Activity.Message;

namespace MouseLight.Coordinator.MessageQueue.TaskUpdate
{
    public class TaskUpdatePublisher
    {
        private CancellationToken _cancellationToken;

        public void Start(CancellationToken token)
        {
            _cancellationToken = token;

            Task.Run(async () => await PublishAsync());
        }

        private async Task PublishAsync()
        {
            var factory = new ConnectionFactory() { HostName = "127.0.0.1", Port = 6520 };

            using var connection = factory.CreateConnection();

            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "TaskExecutionUpdateQueue", durable: false, exclusive: false, autoDelete: false);

            while (!_cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(5000);

                await PublishItem(channel);
            }
        }

        private async Task PublishItem(IModel channel)
        {

            channel.BasicPublish(exchange: "", routingKey: "TaskExecutionUpdateQueue", basicProperties: null, body: Encoding.UTF8.GetBytes(JsonSerializer.Serialize(new TaskExecutionUpdateMessage())));
        }
    }
}
