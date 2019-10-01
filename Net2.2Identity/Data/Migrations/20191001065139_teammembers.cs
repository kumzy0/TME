using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Net2._2Identity.Data.Migrations
{
    public partial class teammembers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TeamId",
                table: "Members",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Members_TeamId",
                table: "Members",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Teams_TeamId",
                table: "Members",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Teams_TeamId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_TeamId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Members");
        }
    }
}
