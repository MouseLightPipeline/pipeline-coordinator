using System;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace MouseLight.Coordinator.MessageQueue.TaskUpdate
{
    public class TaskUpdatePublisher
    {
        public TaskUpdatePublisher()
        {
        }

        public void Start()
        {
            Task.Run(async () => await PublishAsync());
        }

        private async Task PublishAsync()
        {
            var factory = new ConnectionFactory() { HostName = "127.0.0.1", Port = 6520 };

            using var connection = factory.CreateConnection();

            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "TaskExecutionUpdateQueue", durable: false, exclusive: false);
            
            while (/*!_cancellationToken.IsCancellationRequested*/ true)
            {
                await Task.Delay(5000);

                channel.BasicPublish(exchange: "", routingKey: "TaskExecutionUpdateQueue", basicProperties: null, body: Encoding.UTF8.GetBytes("Hello World"));

                //await _taskQueue.EnqueueAsync(new TaskUpdateWorkItem());
            }
            
        }
    }
}
