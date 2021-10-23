using System;
using System.Text.Json.Serialization;

namespace MouseLight.Core.Model.Activity.Message
{
    public class TaskExecutionMessage
    {
        public Guid Id { get; set; }
    
        public Guid ProjectId { get; set; }

        public string TileId;

        public int? JobId { get; set; }

        public string JobName { get; set; }

        public TaskExecutionStatus ExecutionStatus { get; set; }

        public DateTime WhenCreated { get; set; }
    }
}
