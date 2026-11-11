using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace student_management_be_dotnet.Migrations
{
    /// <inheritdoc />
    public partial class Teacher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Teachers",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Teachers",
                type: "longtext",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Teachers");
        }
    }
}
