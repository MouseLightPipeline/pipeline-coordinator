using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MouseLight.Core.Model
{
    public class PipelineStageFunction : PersistentSoftDeleteModel
    {
        [Column("name")]
        public string Name { get; set; }
    }
}
