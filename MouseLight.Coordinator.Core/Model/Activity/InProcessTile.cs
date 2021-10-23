
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MouseLight.Core.Model.Activity
{
    public class ToProcessTile : PersistentModel
    {
        [Column("tile_id")]
        public Guid TileId { get; set; }

        [Column("stage_id")]
        public Guid StageId { get; set; }

        [Column("task_execution_id")]
        public Guid TaskExecutionId { get; set; }

        [Column("worker_id")]
        public Guid WorkerId { get; set; }

        [Column("worker_task_execution_id")]
        public Guid WorkerTaskExecutionId { get; set; }

        [Column("worker_last_seen", TypeName = "timestamp with time zone")]
        public DateTime WhenWorkerLastSeen { get; set; }
    }
}
