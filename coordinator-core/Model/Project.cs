using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MouseLight.Core.Model
{
    public class Project : PersistentModel
    {
        public Project()
        {
            PipelineStages = new HashSet<PipelineStage>();
        }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("sample_number")]
        public int? SampleNumber { get; set; }

        [Column("root_path")]
        public string RootPath { get; set; }

        [Column("log_root_path")]
        public string LogRootPath { get; set; }

        [Column("sample_x_min")]
        public int? SampleXMin { get; set; }

        [Column("sample_x_max")]
        public int? SampleXMax { get; set; }

        [Column("sample_y_min")]
        public int? SampleYMin { get; set; }

        [Column("sample_y_max")]
        public int? SampleYMax { get; set; }

        [Column("sample_z_min")]
        public int? SampleZMin { get; set; }

        [Column("sample_z_max")]
        public int? SampleZMax { get; set; }

        [Column("region_x_min")]
        public int? RegionXMin { get; set; }

        [Column("region_x_max")]
        public int? RegionXMax { get; set; }

        [Column("region_y_min")]
        public int? RegionYMin { get; set; }

        [Column("region_y_max")]
        public int? RegionYMax { get; set; }

        [Column("region_z_min")]
        public int? RegionZMin { get; set; }

        [Column("region_z_max")]
        public int? RegionZMax { get; set; }

        [Column("user_parameters")]
        public string UserParameters { get; set; }

        [Column("plane_markers")]
        public string PlaneMarkers { get; set; }

        [Column("is_processing")]
        public bool? IsProcessing { get; set; }

        [Column("input_source_state")]
        public int? InputSourceState { get; set; }

        [Column("last_seen_input_source", TypeName = "timestamp with time zone")]
        public DateTime? LastSeenInputSource { get; set; }

        [Column("last_checked_input_source", TypeName = "timestamp with time zone")]
        public DateTime? LastCheckedInputSource { get; set; }

        [InverseProperty(nameof(PipelineStage.Project))]
        public virtual ICollection<PipelineStage> PipelineStages { get; set; }
    }
}
