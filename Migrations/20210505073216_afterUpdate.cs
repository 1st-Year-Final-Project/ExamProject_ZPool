using Microsoft.EntityFrameworkCore.Migrations;

namespace ZPool.Migrations
{
    public partial class afterUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_AspNetUsers_AppUserId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Rides_RideId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_AspNetUsers_AppUserId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Rides_Cars_CarId",
                table: "Rides");

            migrationBuilder.RenameColumn(
                name: "CarId",
                table: "Rides",
                newName: "CarID");

            migrationBuilder.RenameColumn(
                name: "RideId",
                table: "Rides",
                newName: "RideID");

            migrationBuilder.RenameIndex(
                name: "IX_Rides_CarId",
                table: "Rides",
                newName: "IX_Rides_CarID");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Cars",
                newName: "AppUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_AppUserId",
                table: "Cars",
                newName: "IX_Cars_AppUserID");

            migrationBuilder.RenameColumn(
                name: "RideId",
                table: "Bookings",
                newName: "RideID");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Bookings",
                newName: "AppUserID");

            migrationBuilder.RenameColumn(
                name: "BookingId",
                table: "Bookings",
                newName: "BookingID");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_RideId",
                table: "Bookings",
                newName: "IX_Bookings_RideID");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_AppUserId",
                table: "Bookings",
                newName: "IX_Bookings_AppUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_AspNetUsers_AppUserID",
                table: "Bookings",
                column: "AppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Rides_RideID",
                table: "Bookings",
                column: "RideID",
                principalTable: "Rides",
                principalColumn: "RideID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_AspNetUsers_AppUserID",
                table: "Cars",
                column: "AppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rides_Cars_CarID",
                table: "Rides",
                column: "CarID",
                principalTable: "Cars",
                principalColumn: "CarID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_AspNetUsers_AppUserID",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Rides_RideID",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_AspNetUsers_AppUserID",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Rides_Cars_CarID",
                table: "Rides");

            migrationBuilder.RenameColumn(
                name: "CarID",
                table: "Rides",
                newName: "CarId");

            migrationBuilder.RenameColumn(
                name: "RideID",
                table: "Rides",
                newName: "RideId");

            migrationBuilder.RenameIndex(
                name: "IX_Rides_CarID",
                table: "Rides",
                newName: "IX_Rides_CarId");

            migrationBuilder.RenameColumn(
                name: "AppUserID",
                table: "Cars",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_AppUserID",
                table: "Cars",
                newName: "IX_Cars_AppUserId");

            migrationBuilder.RenameColumn(
                name: "RideID",
                table: "Bookings",
                newName: "RideId");

            migrationBuilder.RenameColumn(
                name: "AppUserID",
                table: "Bookings",
                newName: "AppUserId");

            migrationBuilder.RenameColumn(
                name: "BookingID",
                table: "Bookings",
                newName: "BookingId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_RideID",
                table: "Bookings",
                newName: "IX_Bookings_RideId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_AppUserID",
                table: "Bookings",
                newName: "IX_Bookings_AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_AspNetUsers_AppUserId",
                table: "Bookings",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Rides_RideId",
                table: "Bookings",
                column: "RideId",
                principalTable: "Rides",
                principalColumn: "RideId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_AspNetUsers_AppUserId",
                table: "Cars",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rides_Cars_CarId",
                table: "Rides",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
