using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    public partial class AddIsDomesticToBuyer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Buyers");

            migrationBuilder.AddColumn<bool>(
                name: "IsDomestic",
                table: "Buyers",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDomestic",
                table: "Buyers");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Buyers",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
