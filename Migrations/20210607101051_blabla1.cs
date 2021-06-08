using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZPool.Migrations
{
    public partial class blabla1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReviewDate = table.Column<DateTime>(nullable: false),
                    MessageBody = table.Column<string>(maxLength: 240, nullable: false),
                    ReviewerId = table.Column<int>(nullable: false),
                    RevieweeId = table.Column<int>(nullable: false),
                    RideId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_RevieweeId",
                        column: x => x.RevieweeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Reviews_Rides_RideId",
                        column: x => x.RideId,
                        principalTable: "Rides",
                        principalColumn: "RideID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "e4e60fe4-c2bc-4ac6-b127-1c34de22cf45");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f2fb9936-ddb4-49ff-811e-4973524fa8cb", "AQAAAAEAACcQAAAAEJ+KE8PO6TTiXpx+pC2xV5v15h7r++IPnUpzPv7y1ezY4queC4PUjqLGIoZOKMExWw==", "3c9f4ef0-1aa5-47cd-ac96-3f7d4df9a976" });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_RevieweeId",
                table: "Reviews",
                column: "RevieweeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ReviewerId",
                table: "Reviews",
                column: "ReviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_RideId",
                table: "Reviews",
                column: "RideId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "879d5eca-fb01-443b-8caf-c0791bea5332");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2421cf05-c560-4e1d-bfc2-db7945f66981", "AQAAAAEAACcQAAAAEFv6k9E1gssIkEOrbJnzwTTFoOjYpS60am6264yHK5JGLWZCZ8v/aGBHfAXyBQEPGQ==", "64475210-9ed5-43c4-892d-fa6cc026f191" });
        }
    }
}
