using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballCrimes.API.Migrations
{
    public partial class ChangeCrimeDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Month",
                table: "Crimes");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Crimes");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Crimes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Crimes");

            migrationBuilder.AddColumn<int>(
                name: "Month",
                table: "Crimes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Crimes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
