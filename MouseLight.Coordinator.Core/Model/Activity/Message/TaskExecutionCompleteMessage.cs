using System;

namespace MouseLight.Core.Model.Activity.Message
{
    public class TaskExecutionCompleteMessage : TaskExecutionUpdateMessage
    {
        public TaskCompletionResult CompletionResult { get; set; }

        public int? ExitCode { get; set; }

        public DateTime? WhenCompleted { get; set; }
    }
}
