using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClickWise.Data.Migrations
{
    /// <inheritdoc />
    public partial class _7logingood : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Users",
                newName: "UpDatedAt");

            migrationBuilder.AddColumn<bool>(
                name: "RegisterStudent",
                table: "Students",
                type: "tinyint(1)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegisterStudent",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "UpDatedAt",
                table: "Users",
                newName: "UpdatedAt");
        }
    }
}
