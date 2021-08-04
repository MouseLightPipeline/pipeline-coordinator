using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MouseLight.Core.Model
{
    public class PersistentSoftDeleteModel : PersistentModel
    {
        [Column("deleted_at", TypeName = "timestamp with time zone")]
        public DateTime? WhenDeleted { get; set; }
    }
}
