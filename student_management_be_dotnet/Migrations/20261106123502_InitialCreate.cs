using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace student_management_be_dotnet.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Degree",
                table: "Teachers",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Teachers",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "JoinDate",
                table: "Teachers",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Teachers",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "Teachers",
                type: "longtext",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Degree",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "JoinDate",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Subject",
                table: "Teachers");
        }
    }
}
