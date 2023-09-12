using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    public partial class IsChargedAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "InvoiceHeaders");

            migrationBuilder.AddColumn<bool>(
                name: "IsCharged",
                table: "InvoiceHeaders",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCharged",
                table: "InvoiceHeaders");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "InvoiceHeaders",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
