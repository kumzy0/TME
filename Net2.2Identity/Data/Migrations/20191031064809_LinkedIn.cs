using Microsoft.EntityFrameworkCore.Migrations;

namespace Net2._2Identity.Data.Migrations
{
    public partial class LinkedIn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LinkedIn",
                table: "Mentors",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkedIn",
                table: "Mentors");
        }
    }
}
