using System;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace MouseLight.Core.Threading
{
    public class BackgroundTaskQueue<T> : IBackgroundTaskQueue<T>
    {
        private readonly Channel<T> _queue;

        public BackgroundTaskQueue()
        {
            _queue = Channel.CreateUnbounded<T>();
        }

        public async ValueTask EnqueueAsync(T workItem)
        {
            if (workItem == null)
            {
                throw new ArgumentNullException(nameof(workItem));
            }

            await _queue.Writer.WriteAsync(workItem);
        }

        public async ValueTask<T> DequeueAsync(CancellationToken cancellationToken)
        {
            return await _queue.Reader.ReadAsync(cancellationToken);
        }
    }
}
