using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cd_academic_degree",
                columns: table => new
                {
                    academic_degree_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи научной степени")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_academic_degree_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "Название научной степени")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_academic_degree_academic_degree_id", x => x.academic_degree_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_department",
                columns: table => new
                {
                    department_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи кафедры")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_department_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "Название кафедры"),
                    c_department_creation_date = table.Column<DateTime>(type: "timestamp", nullable: false, comment: "Дата основания кафедры"),
                    c_department_main_professor = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "Старший преподаватель кафедры"),
                    c_department_professors_amount = table.Column<int>(type: "INT", nullable: false, comment: "Количество профессоров")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_department_department_id", x => x.department_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_discipline",
                columns: table => new
                {
                    discipline_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи дисциплины")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_discipline_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "Название дисциплины")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_discipline_discipline_id", x => x.discipline_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_post",
                columns: table => new
                {
                    post_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи должности")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_post_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "Название должности")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_post_post_id", x => x.post_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_professor",
                columns: table => new
                {
                    professor_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи профессора")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_professor_first_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "Имя профессора"),
                    c_professor_last_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "Фамилия профессора"),
                    c_professor_middle_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "Отчество профессора"),
                    c_professor_title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "Должность профессора"),
                    f_department_id = table.Column<int>(type: "integer", nullable: false, comment: "ID кафедры")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_professor_professor_id", x => x.professor_id);
                    table.ForeignKey(
                        name: "FK_cd_professor_cd_department_f_department_id",
                        column: x => x.f_department_id,
                        principalTable: "cd_department",
                        principalColumn: "department_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cd_work_time",
                columns: table => new
                {
                    work_time_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи рабочего времени")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_work_time_hours = table.Column<int>(type: "INT", nullable: false, comment: "Количество часов"),
                    f_professor_id = table.Column<int>(type: "integer", nullable: false, comment: "ID профессора"),
                    f_department_id = table.Column<int>(type: "integer", nullable: false, comment: "ID кафедры"),
                    f_discipline_id = table.Column<int>(type: "integer", nullable: false, comment: "ID дисциплины")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_work_time_work_time_id", x => x.work_time_id);
                    table.ForeignKey(
                        name: "FK_cd_work_time_cd_department_f_department_id",
                        column: x => x.f_department_id,
                        principalTable: "cd_department",
                        principalColumn: "department_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cd_work_time_cd_discipline_f_discipline_id",
                        column: x => x.f_discipline_id,
                        principalTable: "cd_discipline",
                        principalColumn: "discipline_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cd_work_time_cd_professor_f_professor_id",
                        column: x => x.f_professor_id,
                        principalTable: "cd_professor",
                        principalColumn: "professor_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cd_professor_f_department_id",
                table: "cd_professor",
                column: "f_department_id");

            migrationBuilder.CreateIndex(
                name: "idx+cd_work_time_fk_f_department_id",
                table: "cd_work_time",
                column: "f_department_id");

            migrationBuilder.CreateIndex(
                name: "idx+cd_work_time_fk_f_discipline_id",
                table: "cd_work_time",
                column: "f_discipline_id");

            migrationBuilder.CreateIndex(
                name: "idx+cd_work_time_fk_f_professor_id",
                table: "cd_work_time",
                column: "f_professor_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cd_academic_degree");

            migrationBuilder.DropTable(
                name: "cd_post");

            migrationBuilder.DropTable(
                name: "cd_work_time");

            migrationBuilder.DropTable(
                name: "cd_discipline");

            migrationBuilder.DropTable(
                name: "cd_professor");

            migrationBuilder.DropTable(
                name: "cd_department");
        }
    }
}
