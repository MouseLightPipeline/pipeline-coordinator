using System;
using System.ComponentModel.DataAnnotations.Schema;

using MouseLight.Core.Model.Activity.Message;

namespace MouseLight.Core.Model.Activity
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
        [Column("id")]
        public Guid Id {get; set; }

        [Column("pipeline_stage_id")]
        public Guid PipelineStageId { get; set; }

        [Column("tile_id")]
        public Guid TileId;

        [Column("worker_id")]
        public Guid WorkerId { get; set; }

        [Column("task_definition_id")]
        public Guid TaskDefinitionId { get; set; }

        [Column("queue_type")]
        public WorkQueueKind WorkerQueueType { get; set; }

        [Column("local_work_units")]
        public int LocalWorkUnits { get; set; }

        [Column("cluster_work_units")]
        public int ClusterWorkUnits { get; set; }

        [Column("resolved_output_path")]
        public string ResolvedOutputPath { get; set; }

        [Column("resolved_script")]
        public string ResolvedScript { get; set; }

        [Column("resolved_interpreter")]
        public string ResolvedInterpreter { get; set; }

        [Column("resolved_script_args")]
        public string ResolvedScriptArgs { get; set; }

        [Column("resolved_cluster_args")]
        public string ResolvedClusterArgs { get; set; }

        [Column("resolved_log_path")]
        public string ResolvedLogPath { get; set; }

        [Column("expected_exit_code")]
        public int ExpectedExitCode { get; set; }

        [Column("job_id")]
        public int? JobId { get; set; }

        [Column("job_name")]
        public string JobName { get; set; }

        [Column("execution_status_code")]
        public TaskExecutionStatus ExecutionStatus { get; set; }

        [Column("completion_status_code")]
        public TaskCompletionResult CompletionResult { get; set; }

        [Column("last_process_status_code")]
        public int LastProcessStatusCode { get; set; }

        [Column("cpu_time_seconds")]
        public double? CpuTimeSeconds { get; set; }

        [Column("max_cpu_percent")]
        public double? MaxCpuPercent { get; set; }

        [Column("max_memory_mb")]
        public double? MaxMemoryMB { get; set; }

        [Column("exit_code")]
        public int? ExitCode { get; set; }

        [Column("submitted_at")]
        public DateTime WhenSubmitted { get; set; }

        [Column("started_at")]
        public DateTime? WhenStarted { get; set; }

        [Column("completed_at")]
        public DateTime? WhenCompleted { get; set; }

        public TaskExecution() { }

        public TaskExecution(TaskExecutionUpdateMessage message)
        {
            Id = message.Id;

            Update(message);
        }

        public void Update(TaskExecutionUpdateMessage message)
        {
            JobId = message.JobId;
            JobName = message.JobName;
            ExecutionStatus = message.ExecutionStatus;
            LastProcessStatusCode = message.LastProcessStatusCode;
            CpuTimeSeconds = message.CpuTimeSeconds;
            MaxCpuPercent = message.MaxCpuPercent;
            MaxMemoryMB = message.MaxMemoryMB;
            WhenSubmitted = message.WhenSubmitted;
            WhenStarted = message.WhenStarted;
        }
    }
}
