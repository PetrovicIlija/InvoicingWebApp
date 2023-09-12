using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    public partial class AddServiceIdForeignKeyToInvoiceItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "InvoiceDetails",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_ServiceId",
                table: "InvoiceDetails",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetails_Services_ServiceId",
                table: "InvoiceDetails",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetails_Services_ServiceId",
                table: "InvoiceDetails");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceDetails_ServiceId",
                table: "InvoiceDetails");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "InvoiceDetails");
        }
    }
}
