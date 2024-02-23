using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SinemaBiletSatis.Data.Migrations
{
    /// <inheritdoc />
    public partial class initialCreateiki : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kullanicilar_Rol_RolId",
                table: "Kullanicilar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rol",
                table: "Rol");

            migrationBuilder.RenameTable(
                name: "Rol",
                newName: "Roller");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roller",
                table: "Roller",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 1,
                column: "EklenmeTarihi",
                value: new DateTime(2024, 1, 23, 1, 58, 28, 32, DateTimeKind.Local).AddTicks(2657));

            migrationBuilder.AddForeignKey(
                name: "FK_Kullanicilar_Roller_RolId",
                table: "Kullanicilar",
                column: "RolId",
                principalTable: "Roller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kullanicilar_Roller_RolId",
                table: "Kullanicilar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roller",
                table: "Roller");

            migrationBuilder.RenameTable(
                name: "Roller",
                newName: "Rol");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rol",
                table: "Rol",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 1,
                column: "EklenmeTarihi",
                value: new DateTime(2024, 1, 22, 20, 46, 31, 527, DateTimeKind.Local).AddTicks(3401));

            migrationBuilder.AddForeignKey(
                name: "FK_Kullanicilar_Rol_RolId",
                table: "Kullanicilar",
                column: "RolId",
                principalTable: "Rol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
