using System;
using System.Text.Json.Serialization;

namespace MouseLight.Core.Model.Activity.Message
{
    public class TaskExecutionUpdateMessage : TaskExecutionMessage
    {
        public int LastProcessStatusCode { get; set; }

        public double? CpuTimeSeconds { get; set; }

        public double? MaxCpuPercent { get; set; }

        public double? MaxMemoryMB { get; set; }

        public DateTime WhenSubmitted { get; set; }

        public DateTime? WhenStarted { get; set; }
    }
}
