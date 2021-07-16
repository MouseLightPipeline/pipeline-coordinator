﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MouseLight.Core.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MouseLight.Core.Migrations
{
    [DbContext(typeof(PipelineContext))]
    [Migration("20210716222458_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "en_US.utf8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("MouseLight.Core.Model.PipelineStage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_at");

                    b.Property<int?>("Depth")
                        .HasColumnType("integer")
                        .HasColumnName("depth");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("DstPath")
                        .HasColumnType("text")
                        .HasColumnName("dst_path");

                    b.Property<int?>("FunctionType")
                        .HasColumnType("integer")
                        .HasColumnName("function_type");

                    b.Property<bool?>("IsProcessing")
                        .HasColumnType("boolean")
                        .HasColumnName("is_processing");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<Guid?>("PreviousStageId")
                        .HasColumnType("uuid")
                        .HasColumnName("previous_stage_id");

                    b.Property<Guid?>("ProjectId")
                        .HasColumnType("uuid")
                        .HasColumnName("project_id");

                    b.Property<Guid?>("TaskId")
                        .HasColumnType("uuid")
                        .HasColumnName("task_id");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<string>("UserParameters")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasColumnName("user_parameters")
                        .HasDefaultValueSql("'{}'::text");

                    b.HasKey("Id");

                    b.HasIndex("PreviousStageId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("TaskId");

                    b.ToTable("PipelineStages");
                });

            modelBuilder.Entity("MouseLight.Core.Model.PipelineStageFunction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_at");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("PipelineStageFunctions");
                });

            modelBuilder.Entity("MouseLight.Core.Model.PipelineWorker", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Address")
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<string>("Arch")
                        .HasColumnType("text")
                        .HasColumnName("arch");

                    b.Property<double?>("ClusterWorkCapacity")
                        .HasColumnType("double precision")
                        .HasColumnName("cluster_work_capacity");

                    b.Property<int?>("CpuCount")
                        .HasColumnType("integer")
                        .HasColumnName("cpu_count");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_at");

                    b.Property<double?>("FreeMemory")
                        .HasColumnType("double precision")
                        .HasColumnName("free_memory");

                    b.Property<bool?>("IsInSchedulerPool")
                        .HasColumnType("boolean")
                        .HasColumnName("is_in_scheduler_pool");

                    b.Property<DateTime?>("LastSeen")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_seen");

                    b.Property<double?>("LoadAverage")
                        .HasColumnType("double precision")
                        .HasColumnName("load_average");

                    b.Property<double?>("LocalWorkCapacity")
                        .HasColumnType("double precision")
                        .HasColumnName("local_work_capacity");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("OsType")
                        .HasColumnType("text")
                        .HasColumnName("os_type");

                    b.Property<string>("Platform")
                        .HasColumnType("text")
                        .HasColumnName("platform");

                    b.Property<int?>("Port")
                        .HasColumnType("integer")
                        .HasColumnName("port");

                    b.Property<string>("Release")
                        .HasColumnType("text")
                        .HasColumnName("release");

                    b.Property<double?>("TotalMemory")
                        .HasColumnType("double precision")
                        .HasColumnName("total_memory");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<Guid?>("WorkerId")
                        .HasColumnType("uuid")
                        .HasColumnName("worker_id");

                    b.HasKey("Id");

                    b.ToTable("PipelineWorkers");
                });

            modelBuilder.Entity("MouseLight.Core.Model.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_at");

                    b.Property<string>("Description")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasColumnName("description")
                        .HasDefaultValueSql("''::text");

                    b.Property<int?>("InputSourceState")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("input_source_state")
                        .HasDefaultValueSql("0");

                    b.Property<bool?>("IsProcessing")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasColumnName("is_processing")
                        .HasDefaultValueSql("false");

                    b.Property<DateTime?>("LastCheckedInputSource")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_checked_input_source");

                    b.Property<DateTime?>("LastSeenInputSource")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_seen_input_source");

                    b.Property<string>("LogRootPath")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasColumnName("log_root_path")
                        .HasDefaultValueSql("''::text");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("PlaneMarkers")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasColumnName("plane_markers")
                        .HasDefaultValueSql("'{\"x\": [], \"y\": [], \"z\": []}'::text");

                    b.Property<int?>("RegionXMax")
                        .HasColumnType("integer")
                        .HasColumnName("region_x_max");

                    b.Property<int?>("RegionXMin")
                        .HasColumnType("integer")
                        .HasColumnName("region_x_min");

                    b.Property<int?>("RegionYMax")
                        .HasColumnType("integer")
                        .HasColumnName("region_y_max");

                    b.Property<int?>("RegionYMin")
                        .HasColumnType("integer")
                        .HasColumnName("region_y_min");

                    b.Property<int?>("RegionZMax")
                        .HasColumnType("integer")
                        .HasColumnName("region_z_max");

                    b.Property<int?>("RegionZMin")
                        .HasColumnType("integer")
                        .HasColumnName("region_z_min");

                    b.Property<string>("RootPath")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasColumnName("root_path")
                        .HasDefaultValueSql("''::text");

                    b.Property<int?>("SampleNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("sample_number")
                        .HasDefaultValueSql("'-1'::integer");

                    b.Property<int?>("SampleXMax")
                        .HasColumnType("integer")
                        .HasColumnName("sample_x_max");

                    b.Property<int?>("SampleXMin")
                        .HasColumnType("integer")
                        .HasColumnName("sample_x_min");

                    b.Property<int?>("SampleYMax")
                        .HasColumnType("integer")
                        .HasColumnName("sample_y_max");

                    b.Property<int?>("SampleYMin")
                        .HasColumnType("integer")
                        .HasColumnName("sample_y_min");

                    b.Property<int?>("SampleZMax")
                        .HasColumnType("integer")
                        .HasColumnName("sample_z_max");

                    b.Property<int?>("SampleZMin")
                        .HasColumnType("integer")
                        .HasColumnName("sample_z_min");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<string>("UserParameters")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasColumnName("user_parameters")
                        .HasDefaultValueSql("'{}'::text");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("MouseLight.Core.Model.TaskDefinition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("ClusterArgs")
                        .HasColumnType("text")
                        .HasColumnName("cluster_args");

                    b.Property<double?>("ClusterWorkUnits")
                        .HasColumnType("double precision")
                        .HasColumnName("cluster_work_units");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_at");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<int?>("ExpectedExitCode")
                        .HasColumnType("integer")
                        .HasColumnName("expected_exit_code");

                    b.Property<string>("Interpreter")
                        .HasColumnType("text")
                        .HasColumnName("interpreter");

                    b.Property<double?>("LocalWorkUnits")
                        .HasColumnType("double precision")
                        .HasColumnName("local_work_units");

                    b.Property<string>("LogPrefix")
                        .HasColumnType("text")
                        .HasColumnName("log_prefix");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Script")
                        .HasColumnType("text")
                        .HasColumnName("script");

                    b.Property<string>("ScriptArgs")
                        .HasColumnType("text")
                        .HasColumnName("script_args");

                    b.Property<Guid?>("TaskRepositoryId")
                        .HasColumnType("uuid")
                        .HasColumnName("task_repository_id");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("TaskRepositoryId");

                    b.ToTable("TaskDefinitions");
                });

            modelBuilder.Entity("MouseLight.Core.Model.TaskRepository", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_at");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Location")
                        .HasColumnType("text")
                        .HasColumnName("location");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("TaskRepositories");
                });

            modelBuilder.Entity("MouseLight.Core.Model.PipelineStage", b =>
                {
                    b.HasOne("MouseLight.Core.Model.PipelineStage", "PreviousStage")
                        .WithMany("InversePreviousStage")
                        .HasForeignKey("PreviousStageId")
                        .HasConstraintName("PipelineStages_previous_stage_id_fkey");

                    b.HasOne("MouseLight.Core.Model.Project", "Project")
                        .WithMany("PipelineStages")
                        .HasForeignKey("ProjectId")
                        .HasConstraintName("PipelineStages_project_id_fkey");

                    b.HasOne("MouseLight.Core.Model.TaskDefinition", "Task")
                        .WithMany("PipelineStages")
                        .HasForeignKey("TaskId")
                        .HasConstraintName("PipelineStages_task_id_fkey");

                    b.Navigation("PreviousStage");

                    b.Navigation("Project");

                    b.Navigation("Task");
                });

            modelBuilder.Entity("MouseLight.Core.Model.TaskDefinition", b =>
                {
                    b.HasOne("MouseLight.Core.Model.TaskRepository", "TaskRepository")
                        .WithMany("TaskDefinitions")
                        .HasForeignKey("TaskRepositoryId")
                        .HasConstraintName("TaskDefinitions_task_repository_id_fkey");

                    b.Navigation("TaskRepository");
                });

            modelBuilder.Entity("MouseLight.Core.Model.PipelineStage", b =>
                {
                    b.Navigation("InversePreviousStage");
                });

            modelBuilder.Entity("MouseLight.Core.Model.Project", b =>
                {
                    b.Navigation("PipelineStages");
                });

            modelBuilder.Entity("MouseLight.Core.Model.TaskDefinition", b =>
                {
                    b.Navigation("PipelineStages");
                });

            modelBuilder.Entity("MouseLight.Core.Model.TaskRepository", b =>
                {
                    b.Navigation("TaskDefinitions");
                });
#pragma warning restore 612, 618
        }
    }
}
