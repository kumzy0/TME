using Microsoft.EntityFrameworkCore.Migrations;

namespace Net2._2Identity.Data.Migrations
{
    public partial class teamgroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "JHSCGroup",
                table: "Teams",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JHSCGroup",
                table: "Teams");
        }
    }
}
