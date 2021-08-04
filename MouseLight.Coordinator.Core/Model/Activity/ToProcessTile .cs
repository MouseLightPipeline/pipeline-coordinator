
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using MouseLight.Core.Model;

namespace MouseLight.Core.Data.Activity
{
    public class InProcessTile : PersistentModel
    {
        [Column("stage_id")]
        public Guid StageId { get; set; }

        [Column("relative_path")]
        public string RelativePath { get; set; }

        [Column("lat_x")]
        public int LatX { get; set; }

        [Column("lat_y")]
        public int LatY { get; set; }

        [Column("lat_z")]
        public int LatZ { get; set; }
    }
}
