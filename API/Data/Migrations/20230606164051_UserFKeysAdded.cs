using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API.Data.Migrations
{
    public partial class UserFKeysAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceHeader_Buyer_BuyerId",
                table: "InvoiceHeader");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceHeader_Users_AppUserId",
                table: "InvoiceHeader");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItem_InvoiceHeader_InvoiceHeaderId",
                table: "InvoiceItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvoiceItem",
                table: "InvoiceItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvoiceHeader",
                table: "InvoiceHeader");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Buyer",
                table: "Buyer");

            migrationBuilder.RenameTable(
                name: "InvoiceItem",
                newName: "InvoiceDetails");

            migrationBuilder.RenameTable(
                name: "InvoiceHeader",
                newName: "InvoiceHeaders");

            migrationBuilder.RenameTable(
                name: "Buyer",
                newName: "Buyers");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceItem_InvoiceHeaderId",
                table: "InvoiceDetails",
                newName: "IX_InvoiceDetails_InvoiceHeaderId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceHeader_BuyerId",
                table: "InvoiceHeaders",
                newName: "IX_InvoiceHeaders_BuyerId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceHeader_AppUserId",
                table: "InvoiceHeaders",
                newName: "IX_InvoiceHeaders_AppUserId");

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceHeaderId",
                table: "InvoiceDetails",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "InvoiceHeaders",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Buyers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvoiceDetails",
                table: "InvoiceDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvoiceHeaders",
                table: "InvoiceHeaders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Buyers",
                table: "Buyers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    PriceInEuros = table.Column<decimal>(type: "numeric", nullable: false),
                    AppUserId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Users_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buyers_AppUserId",
                table: "Buyers",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_AppUserId",
                table: "Services",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Buyers_Users_AppUserId",
                table: "Buyers",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetails_InvoiceHeaders_InvoiceHeaderId",
                table: "InvoiceDetails",
                column: "InvoiceHeaderId",
                principalTable: "InvoiceHeaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceHeaders_Buyers_BuyerId",
                table: "InvoiceHeaders",
                column: "BuyerId",
                principalTable: "Buyers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceHeaders_Users_AppUserId",
                table: "InvoiceHeaders",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buyers_Users_AppUserId",
                table: "Buyers");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetails_InvoiceHeaders_InvoiceHeaderId",
                table: "InvoiceDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceHeaders_Buyers_BuyerId",
                table: "InvoiceHeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceHeaders_Users_AppUserId",
                table: "InvoiceHeaders");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvoiceHeaders",
                table: "InvoiceHeaders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvoiceDetails",
                table: "InvoiceDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Buyers",
                table: "Buyers");

            migrationBuilder.DropIndex(
                name: "IX_Buyers_AppUserId",
                table: "Buyers");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Buyers");

            migrationBuilder.RenameTable(
                name: "InvoiceHeaders",
                newName: "InvoiceHeader");

            migrationBuilder.RenameTable(
                name: "InvoiceDetails",
                newName: "InvoiceItem");

            migrationBuilder.RenameTable(
                name: "Buyers",
                newName: "Buyer");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceHeaders_BuyerId",
                table: "InvoiceHeader",
                newName: "IX_InvoiceHeader_BuyerId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceHeaders_AppUserId",
                table: "InvoiceHeader",
                newName: "IX_InvoiceHeader_AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceDetails_InvoiceHeaderId",
                table: "InvoiceItem",
                newName: "IX_InvoiceItem_InvoiceHeaderId");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "InvoiceHeader",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceHeaderId",
                table: "InvoiceItem",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvoiceHeader",
                table: "InvoiceHeader",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvoiceItem",
                table: "InvoiceItem",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Buyer",
                table: "Buyer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceHeader_Buyer_BuyerId",
                table: "InvoiceHeader",
                column: "BuyerId",
                principalTable: "Buyer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceHeader_Users_AppUserId",
                table: "InvoiceHeader",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItem_InvoiceHeader_InvoiceHeaderId",
                table: "InvoiceItem",
                column: "InvoiceHeaderId",
                principalTable: "InvoiceHeader",
                principalColumn: "Id");
        }
    }
}
