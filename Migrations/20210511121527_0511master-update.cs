﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace ZPool.Migrations
{
    public partial class _0511masterupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BookingStatus",
                table: "Bookings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookingStatus",
                table: "Bookings");
        }
    }
}
