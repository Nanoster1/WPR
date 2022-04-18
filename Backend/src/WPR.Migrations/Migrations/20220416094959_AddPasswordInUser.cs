using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WPR.Migrations.Migrations
{
    public partial class AddPasswordInUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "password_hash",
                table: "user",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "salt",
                table: "user",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password_hash",
                table: "user");

            migrationBuilder.DropColumn(
                name: "salt",
                table: "user");
        }
    }
}
