using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ChartPictures",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2023, 7, 23, 10, 31, 17, 43, DateTimeKind.Local).AddTicks(4083));

            migrationBuilder.UpdateData(
                table: "ChartPictures",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2023, 7, 23, 10, 31, 17, 43, DateTimeKind.Local).AddTicks(4102));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2023, 7, 23, 10, 31, 17, 43, DateTimeKind.Local).AddTicks(4125));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2023, 7, 23, 10, 31, 17, 43, DateTimeKind.Local).AddTicks(4144));

            migrationBuilder.UpdateData(
                table: "SiteInfos",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2023, 7, 23, 10, 31, 17, 43, DateTimeKind.Local).AddTicks(4006));

            migrationBuilder.UpdateData(
                table: "SiteInfos",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2023, 7, 23, 10, 31, 17, 43, DateTimeKind.Local).AddTicks(4060));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ChartPictures",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2023, 7, 22, 9, 35, 43, 3, DateTimeKind.Local).AddTicks(4267));

            migrationBuilder.UpdateData(
                table: "ChartPictures",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2023, 7, 22, 9, 35, 43, 3, DateTimeKind.Local).AddTicks(4284));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2023, 7, 22, 9, 35, 43, 3, DateTimeKind.Local).AddTicks(4307));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2023, 7, 22, 9, 35, 43, 3, DateTimeKind.Local).AddTicks(4326));

            migrationBuilder.UpdateData(
                table: "SiteInfos",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2023, 7, 22, 9, 35, 43, 3, DateTimeKind.Local).AddTicks(4197));

            migrationBuilder.UpdateData(
                table: "SiteInfos",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2023, 7, 22, 9, 35, 43, 3, DateTimeKind.Local).AddTicks(4243));
        }
    }
}
