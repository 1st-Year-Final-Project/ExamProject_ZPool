using Microsoft.EntityFrameworkCore.Migrations;

namespace ZPool.Migrations
{
    public partial class Rate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RateValue",
                table: "Reviews",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "1fe4e706-ee55-4ffd-a351-707b5d3febda");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "323360a3-4557-4705-b650-48afa0fd885b", "AQAAAAEAACcQAAAAEK+uStLPZQaEU8DaJUy6u3eh6IozDTaX9Dj8ctV2GfpfgFydXzXWOOr5zN3XUJNFiw==", "ce386e78-9cff-471b-baf6-233252a4afe4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RateValue",
                table: "Reviews");

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
        }
    }
}
