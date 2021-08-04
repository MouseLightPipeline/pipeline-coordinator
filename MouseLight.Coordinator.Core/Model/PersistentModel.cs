using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MouseLight.Core.Model
{
    public class PersistentModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("created_at", TypeName = "timestamp with time zone")]
        public DateTime? WhenCreated { get; set; }

        [Column("updated_at", TypeName = "timestamp with time zone")]
        public DateTime? WhenUpdated { get; set; }
    }
}
