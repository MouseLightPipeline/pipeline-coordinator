using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MouseLight.Core.Model
{
    public class TaskRepository : PersistentSoftDeleteModel
    { 
        public TaskRepository()
        {
            TaskDefinitions = new HashSet<TaskDefinition>();
        }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("location")]
        public string Location { get; set; }

        [InverseProperty(nameof(TaskDefinition.TaskRepository))]
        public virtual ICollection<TaskDefinition> TaskDefinitions { get; set; }
    }
}
