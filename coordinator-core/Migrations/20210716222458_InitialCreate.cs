using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MouseLight.Core.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PipelineStageFunctions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PipelineStageFunctions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PipelineWorkers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    worker_id = table.Column<Guid>(type: "uuid", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true),
                    address = table.Column<string>(type: "text", nullable: true),
                    port = table.Column<int>(type: "integer", nullable: true),
                    os_type = table.Column<string>(type: "text", nullable: true),
                    platform = table.Column<string>(type: "text", nullable: true),
                    arch = table.Column<string>(type: "text", nullable: true),
                    release = table.Column<string>(type: "text", nullable: true),
                    cpu_count = table.Column<int>(type: "integer", nullable: true),
                    total_memory = table.Column<double>(type: "double precision", nullable: true),
                    free_memory = table.Column<double>(type: "double precision", nullable: true),
                    load_average = table.Column<double>(type: "double precision", nullable: true),
                    local_work_capacity = table.Column<double>(type: "double precision", nullable: true),
                    cluster_work_capacity = table.Column<double>(type: "double precision", nullable: true),
                    is_in_scheduler_pool = table.Column<bool>(type: "boolean", nullable: true),
                    last_seen = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PipelineWorkers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true, defaultValueSql: "''::text"),
                    sample_number = table.Column<int>(type: "integer", nullable: true, defaultValueSql: "'-1'::integer"),
                    root_path = table.Column<string>(type: "text", nullable: true, defaultValueSql: "''::text"),
                    log_root_path = table.Column<string>(type: "text", nullable: true, defaultValueSql: "''::text"),
                    sample_x_min = table.Column<int>(type: "integer", nullable: true),
                    sample_x_max = table.Column<int>(type: "integer", nullable: true),
                    sample_y_min = table.Column<int>(type: "integer", nullable: true),
                    sample_y_max = table.Column<int>(type: "integer", nullable: true),
                    sample_z_min = table.Column<int>(type: "integer", nullable: true),
                    sample_z_max = table.Column<int>(type: "integer", nullable: true),
                    region_x_min = table.Column<int>(type: "integer", nullable: true),
                    region_x_max = table.Column<int>(type: "integer", nullable: true),
                    region_y_min = table.Column<int>(type: "integer", nullable: true),
                    region_y_max = table.Column<int>(type: "integer", nullable: true),
                    region_z_min = table.Column<int>(type: "integer", nullable: true),
                    region_z_max = table.Column<int>(type: "integer", nullable: true),
                    user_parameters = table.Column<string>(type: "text", nullable: true, defaultValueSql: "'{}'::text"),
                    plane_markers = table.Column<string>(type: "text", nullable: true, defaultValueSql: "'{\"x\": [], \"y\": [], \"z\": []}'::text"),
                    is_processing = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "false"),
                    input_source_state = table.Column<int>(type: "integer", nullable: true, defaultValueSql: "0"),
                    last_seen_input_source = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    last_checked_input_source = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TaskRepositories",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    location = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskRepositories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TaskDefinitions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    script = table.Column<string>(type: "text", nullable: true),
                    interpreter = table.Column<string>(type: "text", nullable: true),
                    script_args = table.Column<string>(type: "text", nullable: true),
                    cluster_args = table.Column<string>(type: "text", nullable: true),
                    expected_exit_code = table.Column<int>(type: "integer", nullable: true),
                    local_work_units = table.Column<double>(type: "double precision", nullable: true),
                    cluster_work_units = table.Column<double>(type: "double precision", nullable: true),
                    log_prefix = table.Column<string>(type: "text", nullable: true),
                    task_repository_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskDefinitions", x => x.id);
                    table.ForeignKey(
                        name: "TaskDefinitions_task_repository_id_fkey",
                        column: x => x.task_repository_id,
                        principalTable: "TaskRepositories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PipelineStages",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    function_type = table.Column<int>(type: "integer", nullable: true),
                    dst_path = table.Column<string>(type: "text", nullable: true),
                    is_processing = table.Column<bool>(type: "boolean", nullable: true),
                    depth = table.Column<int>(type: "integer", nullable: true),
                    project_id = table.Column<Guid>(type: "uuid", nullable: true),
                    task_id = table.Column<Guid>(type: "uuid", nullable: true),
                    previous_stage_id = table.Column<Guid>(type: "uuid", nullable: true),
                    user_parameters = table.Column<string>(type: "text", nullable: true, defaultValueSql: "'{}'::text"),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PipelineStages", x => x.id);
                    table.ForeignKey(
                        name: "PipelineStages_previous_stage_id_fkey",
                        column: x => x.previous_stage_id,
                        principalTable: "PipelineStages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "PipelineStages_project_id_fkey",
                        column: x => x.project_id,
                        principalTable: "Projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "PipelineStages_task_id_fkey",
                        column: x => x.task_id,
                        principalTable: "TaskDefinitions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PipelineStages_previous_stage_id",
                table: "PipelineStages",
                column: "previous_stage_id");

            migrationBuilder.CreateIndex(
                name: "IX_PipelineStages_project_id",
                table: "PipelineStages",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "IX_PipelineStages_task_id",
                table: "PipelineStages",
                column: "task_id");

            migrationBuilder.CreateIndex(
                name: "IX_TaskDefinitions_task_repository_id",
                table: "TaskDefinitions",
                column: "task_repository_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PipelineStageFunctions");

            migrationBuilder.DropTable(
                name: "PipelineStages");

            migrationBuilder.DropTable(
                name: "PipelineWorkers");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "TaskDefinitions");

            migrationBuilder.DropTable(
                name: "TaskRepositories");
        }
    }
}
