using System;

using MouseLight.Core.Model.Activity.Message;
using MouseLight.Core.Threading;

namespace MouseLight.Coordinator.MessageQueue.TaskUpdate
{
    public class TaskUpdateWorkQueue : BackgroundTaskQueue<TaskExecutionUpdateMessage> { }
}
