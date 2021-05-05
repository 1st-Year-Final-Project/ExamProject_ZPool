using Microsoft.EntityFrameworkCore.Migrations;

namespace ZPool.Migrations
{
    public partial class spellingChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_AspNetUsers_AppUserId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Booking");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Booking",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_AspNetUsers_AppUserId",
                table: "Booking",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_AspNetUsers_AppUserId",
                table: "Booking");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Booking",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Booking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_AspNetUsers_AppUserId",
                table: "Booking",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
