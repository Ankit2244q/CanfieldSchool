using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CanfieldSchool.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CanfiledStaffs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsOnLeave = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CanfiledStaffs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CanfiledStudents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RollNumber = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Section = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Stream = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsOnLeave = table.Column<bool>(type: "bit", nullable: false),
                    IsFeeDue = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CanfiledStudents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CanfiledTeachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stream = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeacherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JoinedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsOnLeave = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CanfiledTeachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CanfieldSchoolModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentsId = table.Column<int>(type: "int", nullable: true),
                    TeachersId = table.Column<int>(type: "int", nullable: true),
                    StaffsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CanfieldSchoolModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CanfieldSchoolModels_CanfiledStaffs_StaffsId",
                        column: x => x.StaffsId,
                        principalTable: "CanfiledStaffs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CanfieldSchoolModels_CanfiledStudents_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "CanfiledStudents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CanfieldSchoolModels_CanfiledTeachers_TeachersId",
                        column: x => x.TeachersId,
                        principalTable: "CanfiledTeachers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CanfieldSchoolModels_StaffsId",
                table: "CanfieldSchoolModels",
                column: "StaffsId");

            migrationBuilder.CreateIndex(
                name: "IX_CanfieldSchoolModels_StudentsId",
                table: "CanfieldSchoolModels",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_CanfieldSchoolModels_TeachersId",
                table: "CanfieldSchoolModels",
                column: "TeachersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CanfieldSchoolModels");

            migrationBuilder.DropTable(
                name: "CanfiledStaffs");

            migrationBuilder.DropTable(
                name: "CanfiledStudents");

            migrationBuilder.DropTable(
                name: "CanfiledTeachers");
        }
    }
}
