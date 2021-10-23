using System;

using Microsoft.EntityFrameworkCore;

using MouseLight.Core.Model.Activity;

namespace MouseLight.Core.Data.Activity
{
    public class ProjectActivityDbContext : DbContext
    {
        public virtual DbSet<ActivityTile> Tile { get; set; }

        public virtual DbSet<InProcessTile> InProcess { get; set; }

        public virtual DbSet<ToProcessTile> ToProcess { get; set; }

        public virtual DbSet<TaskExecution> TaskExecution { get; set; }

        private readonly PipelineContextOptions _options;

        public ProjectActivityDbContext(PipelineContextOptions options)
        {
            _options = options;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connection = PipelineContextConnection.ForOptions(_options);

                optionsBuilder.UseNpgsql(connection.ConnectionString);
            }
        }
    }
}
