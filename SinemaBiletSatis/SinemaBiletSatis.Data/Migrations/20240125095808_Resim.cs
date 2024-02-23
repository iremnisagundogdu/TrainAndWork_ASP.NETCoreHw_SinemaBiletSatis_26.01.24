using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SinemaBiletSatis.Data.Migrations
{
    /// <inheritdoc />
    public partial class Resim : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Filmler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 1,
                column: "EklenmeTarihi",
                value: new DateTime(2024, 1, 25, 12, 58, 7, 788, DateTimeKind.Local).AddTicks(3098));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Filmler");

            migrationBuilder.UpdateData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 1,
                column: "EklenmeTarihi",
                value: new DateTime(2024, 1, 23, 1, 58, 28, 32, DateTimeKind.Local).AddTicks(2657));
        }
    }
}
