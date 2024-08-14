using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCrud.Api.Migrations
{
    /// <inheritdoc />
    public partial class Fix_name_student_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK__Students",
                table: "_Students");

            migrationBuilder.RenameTable(
                name: "_Students",
                newName: "Students");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "_Students");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Students",
                table: "_Students",
                column: "Id");
        }
    }
}
