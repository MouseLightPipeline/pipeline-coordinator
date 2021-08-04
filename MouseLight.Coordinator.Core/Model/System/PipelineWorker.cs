using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MouseLight.Core.Model
{
    public class PipelineWorker : PersistentSoftDeleteModel
    {
        [Column("worker_id")]
        public Guid? WorkerId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("address")]
        public string Address { get; set; }

        [Column("port")]
        public int? Port { get; set; }

        [Column("os_type")]
        public string OsType { get; set; }

        [Column("platform")]
        public string Platform { get; set; }

        [Column("arch")]
        public string Arch { get; set; }

        [Column("release")]
        public string Release { get; set; }

        [Column("cpu_count")]
        public int? CpuCount { get; set; }

        [Column("total_memory")]
        public double? TotalMemory { get; set; }

        [Column("free_memory")]
        public double? FreeMemory { get; set; }

        [Column("load_average")]
        public double? LoadAverage { get; set; }

        [Column("local_work_capacity")]
        public double? LocalWorkCapacity { get; set; }

        [Column("cluster_work_capacity")]
        public double? ClusterWorkCapacity { get; set; }

        [Column("is_in_scheduler_pool")]
        public bool? IsInSchedulerPool { get; set; }
        [Column("last_seen", TypeName = "timestamp with time zone")]
        public DateTime? LastSeen { get; set; }
    }
}
