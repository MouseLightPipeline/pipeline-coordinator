using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


using MouseLight.Core.Model;

#nullable disable

namespace MouseLight.Core.Data
{
    public class PipelineContext : DbContext
    {
        public PipelineContext() { }

        public PipelineContext(DbContextOptions<PipelineContext> options) : base(options) { }

        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<PipelineStage> PipelineStages { get; set; }
        public virtual DbSet<TaskDefinition> TaskDefinitions { get; set; }
        public virtual DbSet<TaskRepository> TaskRepositories { get; set; }
        public virtual DbSet<PipelineWorker> PipelineWorkers { get; set; }
        public virtual DbSet<PipelineStageFunction> PipelineStageFunctions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // optionsBuilder.UseNpgsql("Host=localhost;Port=6510;Database=pipeline_production;Username=postgres;Password=pgsecret");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.utf8");

            modelBuilder.Entity<PipelineStage>(entity =>
            {
                entity.Property(e => e.UserParameters).HasDefaultValueSql("'{}'::text");

                entity.HasOne(d => d.PreviousStage)
                    .WithMany(p => p.InversePreviousStage)
                    .HasForeignKey(d => d.PreviousStageId)
                    .HasConstraintName("PipelineStages_previous_stage_id_fkey");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.PipelineStages)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("PipelineStages_project_id_fkey");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.PipelineStages)
                    .HasForeignKey(d => d.TaskId)
                    .HasConstraintName("PipelineStages_task_id_fkey");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.Description).HasDefaultValueSql("''::text");

                entity.Property(e => e.InputSourceState).HasDefaultValueSql("0");

                entity.Property(e => e.IsProcessing).HasDefaultValueSql("false");

                entity.Property(e => e.LogRootPath).HasDefaultValueSql("''::text");

                entity.Property(e => e.PlaneMarkers).HasDefaultValueSql("'{\"x\": [], \"y\": [], \"z\": []}'::text");

                entity.Property(e => e.RootPath).HasDefaultValueSql("''::text");

                entity.Property(e => e.SampleNumber).HasDefaultValueSql("'-1'::integer");

                entity.Property(e => e.UserParameters).HasDefaultValueSql("'{}'::text");
            });

            modelBuilder.Entity<TaskDefinition>(entity =>
            {
                entity.HasOne(d => d.TaskRepository)
                    .WithMany(p => p.TaskDefinitions)
                    .HasForeignKey(d => d.TaskRepositoryId)
                    .HasConstraintName("TaskDefinitions_task_repository_id_fkey");
            });
        }
    }
}
