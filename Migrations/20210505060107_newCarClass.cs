using Microsoft.EntityFrameworkCore.Migrations;

namespace ZPool.Migrations
{
    public partial class newCarClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Colour",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Make",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "CarId",
                table: "Cars",
                newName: "CarID");

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumberPlate",
                table: "Cars",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "NumberPlate",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "CarID",
                table: "Cars",
                newName: "CarId");

            migrationBuilder.AddColumn<string>(
                name: "Colour",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Make",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
