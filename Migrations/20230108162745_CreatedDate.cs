using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Andronic_Paul_Proiect.Migrations
{
    public partial class CreatedDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PhoneNumber",
                table: "Student",
                type: "decimal(10,0)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Student",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Student");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Student",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,0)");
        }
    }
}
