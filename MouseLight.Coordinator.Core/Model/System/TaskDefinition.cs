using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MouseLight.Core.Model
{
    public class TaskDefinition : PersistentSoftDeleteModel
    {
        public TaskDefinition()
        {
            PipelineStages = new HashSet<PipelineStage>();
        }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("script")]
        public string Script { get; set; }

        [Column("interpreter")]
        public string Interpreter { get; set; }

        [Column("script_args")]
        public string ScriptArgs { get; set; }

        [Column("cluster_args")]
        public string ClusterArgs { get; set; }

        [Column("expected_exit_code")]
        public int? ExpectedExitCode { get; set; }

        [Column("local_work_units")]
        public double? LocalWorkUnits { get; set; }

        [Column("cluster_work_units")]
        public double? ClusterWorkUnits { get; set; }

        [Column("log_prefix")]
        public string LogPrefix { get; set; }

        [Column("task_repository_id")]
        public Guid? TaskRepositoryId { get; set; }

        [ForeignKey(nameof(TaskRepositoryId))]
        [InverseProperty("TaskDefinitions")]
        public virtual TaskRepository TaskRepository { get; set; }

        [InverseProperty(nameof(PipelineStage.Task))]
        public virtual ICollection<PipelineStage> PipelineStages { get; set; }
    }
}
