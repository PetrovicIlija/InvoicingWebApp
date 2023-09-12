using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    public partial class ForeignKeysFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buyers_Users_AppUserId",
                table: "Buyers");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Users_AppUserId",
                table: "Services");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Services",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Buyers",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Buyers_Users_AppUserId",
                table: "Buyers",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Users_AppUserId",
                table: "Services",
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
                name: "FK_Services_Users_AppUserId",
                table: "Services");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Services",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Buyers",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Buyers_Users_AppUserId",
                table: "Buyers",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Users_AppUserId",
                table: "Services",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
