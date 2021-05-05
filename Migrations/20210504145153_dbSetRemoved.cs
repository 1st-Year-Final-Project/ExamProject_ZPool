using Microsoft.EntityFrameworkCore.Migrations;

namespace ZPool.Migrations
{
    public partial class dbSetRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_AspNetUsers_AppUserId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Ride_RideId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Ride_Cars_CarId",
                table: "Ride");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ride",
                table: "Ride");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Booking",
                table: "Booking");

            migrationBuilder.RenameTable(
                name: "Ride",
                newName: "Rides");

            migrationBuilder.RenameTable(
                name: "Booking",
                newName: "Bookings");

            migrationBuilder.RenameIndex(
                name: "IX_Ride_CarId",
                table: "Rides",
                newName: "IX_Rides_CarId");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_RideId",
                table: "Bookings",
                newName: "IX_Bookings_RideId");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_AppUserId",
                table: "Bookings",
                newName: "IX_Bookings_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rides",
                table: "Rides",
                column: "RideId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings",
                column: "BookingId");

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
                name: "FK_Rides_Cars_CarId",
                table: "Rides",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_AspNetUsers_AppUserId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Rides_RideId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Rides_Cars_CarId",
                table: "Rides");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rides",
                table: "Rides");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings");

            migrationBuilder.RenameTable(
                name: "Rides",
                newName: "Ride");

            migrationBuilder.RenameTable(
                name: "Bookings",
                newName: "Booking");

            migrationBuilder.RenameIndex(
                name: "IX_Rides_CarId",
                table: "Ride",
                newName: "IX_Ride_CarId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_RideId",
                table: "Booking",
                newName: "IX_Booking_RideId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_AppUserId",
                table: "Booking",
                newName: "IX_Booking_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ride",
                table: "Ride",
                column: "RideId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Booking",
                table: "Booking",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_AspNetUsers_AppUserId",
                table: "Booking",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Ride_RideId",
                table: "Booking",
                column: "RideId",
                principalTable: "Ride",
                principalColumn: "RideId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ride_Cars_CarId",
                table: "Ride",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
