using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WPR.Migrations.Migrations
{
    public partial class AddDescsInProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "long_desc",
                table: "project",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "short_desc",
                table: "project",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "long_desc",
                table: "project");

            migrationBuilder.DropColumn(
                name: "short_desc",
                table: "project");
        }
    }
}
