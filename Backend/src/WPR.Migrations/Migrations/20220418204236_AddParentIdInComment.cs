using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WPR.Migrations.Migrations
{
    public partial class AddParentIdInComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "creating_date",
                table: "comment");

            migrationBuilder.AddColumn<DateTime>(
                name: "creating_date_time",
                table: "comment",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "parent_id",
                table: "comment",
                type: "uuid",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "creating_date_time",
                table: "comment");

            migrationBuilder.DropColumn(
                name: "parent_id",
                table: "comment");

            migrationBuilder.AddColumn<DateOnly>(
                name: "creating_date",
                table: "comment",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }
    }
}
