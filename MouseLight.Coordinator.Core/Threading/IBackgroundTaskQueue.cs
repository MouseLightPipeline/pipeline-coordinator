using System;
using System.Threading;
using System.Threading.Tasks;

namespace MouseLight.Core.Threading
{
    public interface IBackgroundTaskQueue<T>
    {
        ValueTask EnqueueAsync(T item);

        ValueTask<T> DequeueAsync(CancellationToken token);
    }
}
