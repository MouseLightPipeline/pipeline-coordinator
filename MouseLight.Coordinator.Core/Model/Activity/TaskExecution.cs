using System;
using System.Text.Json.Serialization;

namespace MouseLight.Core.Model
{
    public enum TaskExecutionStatus
    {
        Undefined = 0,
        Initializing = 1,
        Running = 2,
        Zombie = 3,   // Was marked initialized/running but can not longer find in process manager list/cluster jobs
        Orphaned = 4, // Found in process manager with metadata that associates to worker, but no linked task in database
        Completed = 5
    }

    public enum TaskCompletionResult
    {
        Unknown = 0,
        Incomplete = 1,
        Cancel = 2,
        Success = 3,
        Error = 4,
        Resubmitted = 5
    }

    public class TaskExecution
    {
        [JsonPropertyName("id")]
        public Guid Id {get; set; }

        [JsonPropertyName("worker_id")]
        public Guid WorkerId { get; set; }

        [JsonPropertyName("remote_task_execution_id")]
        public Guid RemoteTaskExecutionId { get; set; }

        [JsonPropertyName("tile_id")]
        public string TileId;

        [JsonPropertyName("task_definition_id")]
        public Guid TaskDefinitionId { get; set; }

        [JsonPropertyName("pipeline_stage_id")]
        public Guid PipelineStageId { get; set; }

        [JsonPropertyName("queue_type")]
        public WorkQueueKind WorkerQueueType { get; set; }

        [JsonPropertyName("")]
        public int LocalWorkUnits { get; set; }

        [JsonPropertyName("cluster_work_units")]
        public int ClusterWorkUnits { get; set; }

        [JsonPropertyName("resolved_output_path")]
        public string ResolvedOutputPath { get; set; }

        [JsonPropertyName("resolved_script")]
        public string ResolvedScript { get; set; }

        [JsonPropertyName("resolved_interpreter")]
        public string ResolvedInterpreter { get; set; }

        [JsonPropertyName("resolved_script_args")]
        public string ResolvedScriptArgs { get; set; }

        [JsonPropertyName("resolved_cluster_args")]
        public string ResolvedClusterArgs { get; set; }

        [JsonPropertyName("resolved_log_path")]
        public string ResolvedLogPath { get; set; }

        [JsonPropertyName("expected_exit_code")]
        public int ExpectedExitCode { get; set; }

        [JsonPropertyName("job_id")]
        public int? JobId { get; set; }

        [JsonPropertyName("job_name")]
        public string JobName { get; set; }

        [JsonPropertyName("execution_status_code")]
        public TaskExecutionStatus ExecutionStatus { get; set; }

        [JsonPropertyName("completion_status_code")]
        public TaskCompletionResult CompletionResult { get; set; }

        [JsonPropertyName("last_process_status_code")]
        public int LastProcessStatusCode { get; set; }

        [JsonPropertyName("cpu_time_seconds")]
        public double? CpuTimeSeconds { get; set; }

        [JsonPropertyName("max_cpu_percent")]
        public double? MaxCpuPercent { get; set; }

        [JsonPropertyName("max_memory_mb")]
        public double? MaxMemoryMB { get; set; }

        [JsonPropertyName("exit_code")]
        public int? ExitCode { get; set; }

        [JsonPropertyName("submitted_at")]
        public DateTime WhenSubmitted { get; set; }

        [JsonPropertyName("started_at")]
        public DateTime? WhenStarted { get; set; }

        [JsonPropertyName("synchronized_at")]
        public DateTime? WhenCompleted { get; set; }

        public TaskExecution()
        {
        }
    }
}
