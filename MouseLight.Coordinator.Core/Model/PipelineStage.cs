using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MouseLight.Core.Model
{
    public class PipelineStage : PersistentModel
    {
        public PipelineStage()
        {
            InversePreviousStage = new HashSet<PipelineStage>();
        }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("function_type")]
        public int? FunctionType { get; set; }

        [Column("dst_path")]
        public string DstPath { get; set; }

        [Column("is_processing")]
        public bool? IsProcessing { get; set; }

        [Column("depth")]
        public int? Depth { get; set; }

        [Column("project_id")]
        public Guid? ProjectId { get; set; }

        [Column("task_id")]
        public Guid? TaskId { get; set; }

        [Column("previous_stage_id")]
        public Guid? PreviousStageId { get; set; }

        [Column("user_parameters")]
        public string UserParameters { get; set; }

        [ForeignKey(nameof(PreviousStageId))]
        [InverseProperty(nameof(PipelineStage.InversePreviousStage))]
        public virtual PipelineStage PreviousStage { get; set; }

        [ForeignKey(nameof(ProjectId))]
        [InverseProperty("PipelineStages")]
        public virtual Project Project { get; set; }

        [ForeignKey(nameof(TaskId))]
        [InverseProperty(nameof(TaskDefinition.PipelineStages))]
        public virtual TaskDefinition Task { get; set; }

        [InverseProperty(nameof(PipelineStage.PreviousStage))]
        public virtual ICollection<PipelineStage> InversePreviousStage { get; set; }
    }
}
