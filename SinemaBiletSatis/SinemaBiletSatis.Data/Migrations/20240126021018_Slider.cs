using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SinemaBiletSatis.Data.Migrations
{
    /// <inheritdoc />
    public partial class Slider : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 1,
                column: "EklenmeTarihi",
                value: new DateTime(2024, 1, 26, 5, 10, 18, 845, DateTimeKind.Local).AddTicks(6729));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 1,
                column: "EklenmeTarihi",
                value: new DateTime(2024, 1, 26, 4, 55, 11, 67, DateTimeKind.Local).AddTicks(9492));
        }
    }
}
