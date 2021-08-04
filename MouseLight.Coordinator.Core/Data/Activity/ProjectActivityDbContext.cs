using System;

using Microsoft.EntityFrameworkCore;

namespace MouseLight.Core.Data.Activity
{
    public class ProjectActivityDbContext: DbContext
    {
        public virtual DbSet<InProcessTile> InProcess { get; set; }

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
