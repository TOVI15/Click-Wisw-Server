using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClickWise.Data.Migrations
{
    /// <inheritdoc />
    public partial class _9goodform : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PreviousSchool",
                table: "StudentDetails");

            migrationBuilder.DropColumn(
                name: "StudyTrack",
                table: "StudentDetails");

            migrationBuilder.RenameColumn(
                name: "SynagogueName",
                table: "StudentDetails",
                newName: "YeshivaName");

            migrationBuilder.RenameColumn(
                name: "SynagogueCity",
                table: "StudentDetails",
                newName: "HealthInsurance");

            migrationBuilder.AddColumn<string>(
                name: "BuildingNumber",
                table: "Students",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "YearsOfStudy",
                table: "StudentDetails",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuildingNumber",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "YeshivaName",
                table: "StudentDetails",
                newName: "SynagogueName");

            migrationBuilder.RenameColumn(
                name: "HealthInsurance",
                table: "StudentDetails",
                newName: "SynagogueCity");

            migrationBuilder.AlterColumn<int>(
                name: "YearsOfStudy",
                table: "StudentDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PreviousSchool",
                table: "StudentDetails",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "StudyTrack",
                table: "StudentDetails",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
