using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication3.Migrations
{
 
    public partial class Initial : Migration
    {

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    city_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    city_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.city_id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    department_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    department_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.department_id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    subject_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    subject_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    GradeLevel = table.Column<int>(type: "integer", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.subject_id);
                });

            migrationBuilder.CreateTable(
                name: "Talabala",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    city_id = table.Column<int>(type: "integer", nullable: false),
                    birth_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    gender = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    grade_level = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    department_id = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talabala", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Talabala_Cities_city_id",
                        column: x => x.city_id,
                        principalTable: "Cities",
                        principalColumn: "city_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Talabala_Departments_department_id",
                        column: x => x.department_id,
                        principalTable: "Departments",
                        principalColumn: "department_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "O'qituvchi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    full_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CityId = table.Column<int>(type: "integer", nullable: false),
                    birth_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    gender = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    SubjectId = table.Column<int>(type: "integer", nullable: false),
                    DepartmentId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_O'qituvchi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_O'qituvchi_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "city_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_O'qituvchi_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "subject_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentsSubjects",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "integer", nullable: false),
                    SubjectId = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Mark = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsSubjects", x => new { x.StudentId, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_StudentsSubjects_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "subject_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentsSubjects_Talabala_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Talabala",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherSubjects",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "integer", nullable: false),
                    SubjectId = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherSubjects", x => new { x.TeacherId, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_TeacherSubjects_O'qituvchi_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "O'qituvchi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherSubjects_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "subject_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "city_id", "city_name" },
                values: new object[,]
                {
                    { 1, "Toshkent" },
                    { 2, "Samarqand" },
                    { 3, "Buxoro" },
                    { 4, "Andijon" },
                    { 5, "Xorazm" },
                    { 6, "Namangan" },
                    { 7, "Farg‘ona" },
                    { 8, "Qashqadaryo" },
                    { 9, "Surxondaryo" },
                    { 10, "Jizzax" },
                    { 11, "Sirdaryo" },
                    { 12, "Navoiy" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "department_id", "CreatedDate", "LastUpdated", "department_name" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 8, 25, 12, 21, 1, 211, DateTimeKind.Utc).AddTicks(8157), new DateTime(2025, 8, 25, 12, 21, 1, 211, DateTimeKind.Utc).AddTicks(8153), "Information" },
                    { 2, new DateTime(2025, 8, 25, 12, 21, 1, 211, DateTimeKind.Utc).AddTicks(8925), new DateTime(2025, 8, 25, 12, 21, 1, 211, DateTimeKind.Utc).AddTicks(8924), "Fizika" },
                    { 3, new DateTime(2025, 8, 25, 12, 21, 1, 211, DateTimeKind.Utc).AddTicks(8927), new DateTime(2025, 8, 25, 12, 21, 1, 211, DateTimeKind.Utc).AddTicks(8927), "Biology" },
                    { 4, new DateTime(2025, 8, 25, 12, 21, 1, 211, DateTimeKind.Utc).AddTicks(8929), new DateTime(2025, 8, 25, 12, 21, 1, 211, DateTimeKind.Utc).AddTicks(8929), "Geography" },
                    { 5, new DateTime(2025, 8, 25, 12, 21, 1, 211, DateTimeKind.Utc).AddTicks(8932), new DateTime(2025, 8, 25, 12, 21, 1, 211, DateTimeKind.Utc).AddTicks(8931), "Kimio" },
                    { 6, new DateTime(2025, 8, 25, 12, 21, 1, 211, DateTimeKind.Utc).AddTicks(8934), new DateTime(2025, 8, 25, 12, 21, 1, 211, DateTimeKind.Utc).AddTicks(8933), "English" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "subject_id", "CreatedDate", "GradeLevel", "IsDeleted", "LastUpdated", "subject_name" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 8, 25, 12, 21, 1, 212, DateTimeKind.Utc).AddTicks(382), 0, false, new DateTime(2025, 8, 25, 12, 21, 1, 212, DateTimeKind.Utc).AddTicks(379), "mathematica" },
                    { 2, new DateTime(2025, 8, 25, 12, 21, 1, 212, DateTimeKind.Utc).AddTicks(1157), 0, false, new DateTime(2025, 8, 25, 12, 21, 1, 212, DateTimeKind.Utc).AddTicks(1156), "Fizika" },
                    { 3, new DateTime(2025, 8, 25, 12, 21, 1, 212, DateTimeKind.Utc).AddTicks(1196), 0, false, new DateTime(2025, 8, 25, 12, 21, 1, 212, DateTimeKind.Utc).AddTicks(1195), "Biology" },
                    { 4, new DateTime(2025, 8, 25, 12, 21, 1, 212, DateTimeKind.Utc).AddTicks(1199), 0, false, new DateTime(2025, 8, 25, 12, 21, 1, 212, DateTimeKind.Utc).AddTicks(1198), "Geography" },
                    { 5, new DateTime(2025, 8, 25, 12, 21, 1, 212, DateTimeKind.Utc).AddTicks(1201), 0, false, new DateTime(2025, 8, 25, 12, 21, 1, 212, DateTimeKind.Utc).AddTicks(1200), "Kimio" },
                    { 6, new DateTime(2025, 8, 25, 12, 21, 1, 212, DateTimeKind.Utc).AddTicks(1203), 0, false, new DateTime(2025, 8, 25, 12, 21, 1, 212, DateTimeKind.Utc).AddTicks(1203), "English" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_O'qituvchi_CityId",
                table: "O'qituvchi",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_O'qituvchi_SubjectId",
                table: "O'qituvchi",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsSubjects_SubjectId",
                table: "StudentsSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Talabala_city_id",
                table: "Talabala",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_Talabala_department_id",
                table: "Talabala",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSubjects_SubjectId",
                table: "TeacherSubjects",
                column: "SubjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentsSubjects");

            migrationBuilder.DropTable(
                name: "TeacherSubjects");

            migrationBuilder.DropTable(
                name: "Talabala");

            migrationBuilder.DropTable(
                name: "O'qituvchi");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Subjects");
        }
    }
}
