using Microsoft.EntityFrameworkCore.Migrations;

namespace ZPool.Migrations
{
    public partial class newTry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Ride_RideID",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_User_UserID",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_User_UserID",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Ride_Cars_CarID",
                table: "Ride");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_Cars_UserID",
                table: "Cars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ride",
                table: "Ride");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Booking",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_UserID",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Booking");

            migrationBuilder.RenameTable(
                name: "Ride",
                newName: "Rides");

            migrationBuilder.RenameTable(
                name: "Booking",
                newName: "Bookings");

            migrationBuilder.RenameIndex(
                name: "IX_Ride_CarID",
                table: "Rides",
                newName: "IX_Rides_CarID");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_RideID",
                table: "Bookings",
                newName: "IX_Bookings_RideID");

            migrationBuilder.AddColumn<int>(
                name: "AppUserID",
                table: "Cars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AppUserID",
                table: "Bookings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rides",
                table: "Rides",
                column: "RideID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings",
                column: "BookingID");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_AppUserID",
                table: "Cars",
                column: "AppUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_AppUserID",
                table: "Bookings",
                column: "AppUserID");

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

            migrationBuilder.DropIndex(
                name: "IX_Cars_AppUserID",
                table: "Cars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rides",
                table: "Rides");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_AppUserID",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "AppUserID",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "AppUserID",
                table: "Bookings");

            migrationBuilder.RenameTable(
                name: "Rides",
                newName: "Ride");

            migrationBuilder.RenameTable(
                name: "Bookings",
                newName: "Booking");

            migrationBuilder.RenameIndex(
                name: "IX_Rides_CarID",
                table: "Ride",
                newName: "IX_Ride_CarID");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_RideID",
                table: "Booking",
                newName: "IX_Booking_RideID");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Booking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ride",
                table: "Ride",
                column: "RideID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Booking",
                table: "Booking",
                column: "BookingID");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstMidName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Introduction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_UserID",
                table: "Cars",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_UserID",
                table: "Booking",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Ride_RideID",
                table: "Booking",
                column: "RideID",
                principalTable: "Ride",
                principalColumn: "RideID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_User_UserID",
                table: "Booking",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_User_UserID",
                table: "Cars",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ride_Cars_CarID",
                table: "Ride",
                column: "CarID",
                principalTable: "Cars",
                principalColumn: "CarID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
