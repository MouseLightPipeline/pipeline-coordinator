
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MouseLight.Core.Model.Activity
{
    public class ActivityTile : PersistentModel
    {
        public Guid InputTileId { get; set; }

        [Column("stage_id")]
        public Guid StageId { get; set; }

        [Column("relative_path")]
        public string RelativePath { get; set; }

        [Column("index")]
        public int Index { get; set; }

        [Column("tile_name")]
        public string TileName { get; set; }

        [Column("stage_status")]
        public int StageStatus { get; set; }

        [Column("lat_x")]
        public int LatX { get; set; }

        [Column("lat_y")]
        public int LatY { get; set; }

        [Column("lat_z")]
        public int LatZ { get; set; }

        [Column("step_x")]
        public int StepX { get; set; }

        [Column("step_y")]
        public int StepY { get; set; }

        [Column("step_z")]
        public int StepZ { get; set; }

    }
}
