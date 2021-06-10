using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZPool.Migrations
{
    public partial class addReviews : Migration
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
                    RateValue = table.Column<int>(nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "94b1072a-6771-4f62-b630-738bdeecb714");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4835a907-fd63-4009-bec7-dbc98984502a", "AQAAAAEAACcQAAAAEF3cFk0cBn71Ri4FDL6HvXMe/1mr4y20GWFI6A0CuOCRIrGHH1uwH7DKCHzuV7E4TQ==", "88621e62-70e6-455c-a127-d7b6f6d113e7" });

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
                value: "3f47080f-a4bd-4ec6-bed8-f16c356cf96d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fa048f6b-9b41-4980-90dc-137568688ee7", "AQAAAAEAACcQAAAAEN0V+GRnasu9OnuRMn6Dq4x9GLkFU3+B6LQ2hQ6KXwJg2MRDPcgyWcTo0jXxW7X9IA==", "df51544c-e17f-4d15-bc19-e1cd97cd3946" });
        }
    }
}
