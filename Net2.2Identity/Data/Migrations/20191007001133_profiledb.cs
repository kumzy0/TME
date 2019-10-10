using Microsoft.EntityFrameworkCore.Migrations;

namespace Net2._2Identity.Data.Migrations
{
    public partial class profiledb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Mentors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfileUrl",
                table: "Mentors",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Mentors");

            migrationBuilder.DropColumn(
                name: "ProfileUrl",
                table: "Mentors");
        }
    }
}
