
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using MouseLight.Core.Model;

namespace MouseLight.Core.Model.Activity
{
    public class InProcessTile : PersistentModel
    {
        [Column("tile_id")]
        public Guid TileId { get; set; }

        [Column("stage_id")]
        public Guid StageId { get; set; }
    }
}
