using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballCrimes.API.Migrations
{
    public partial class AddedNavigationProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Stadiums_StadiumId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_StadiumId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "StadiumId",
                table: "Teams");

            migrationBuilder.AddColumn<Guid>(
                name: "TeamId",
                table: "Stadiums",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Stadiums_TeamId",
                table: "Stadiums",
                column: "TeamId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Stadiums_Teams_TeamId",
                table: "Stadiums",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stadiums_Teams_TeamId",
                table: "Stadiums");

            migrationBuilder.DropIndex(
                name: "IX_Stadiums_TeamId",
                table: "Stadiums");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Stadiums");

            migrationBuilder.AddColumn<Guid>(
                name: "StadiumId",
                table: "Teams",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_StadiumId",
                table: "Teams",
                column: "StadiumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Stadiums_StadiumId",
                table: "Teams",
                column: "StadiumId",
                principalTable: "Stadiums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
