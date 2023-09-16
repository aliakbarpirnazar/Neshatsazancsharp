using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTBLSiteInfo1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LinkTelegram",
                table: "SiteInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkWhatsApp",
                table: "SiteInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Linkinstagram",
                table: "SiteInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ChartPictures",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2023, 7, 9, 11, 36, 33, 116, DateTimeKind.Local).AddTicks(9599));

            migrationBuilder.UpdateData(
                table: "ChartPictures",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2023, 7, 9, 11, 36, 33, 116, DateTimeKind.Local).AddTicks(9622));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2023, 7, 9, 11, 36, 33, 116, DateTimeKind.Local).AddTicks(9648));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2023, 7, 9, 11, 36, 33, 116, DateTimeKind.Local).AddTicks(9669));

            migrationBuilder.UpdateData(
                table: "SiteInfos",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreationDate", "LinkTelegram", "LinkWhatsApp", "Linkinstagram" },
                values: new object[] { new DateTime(2023, 7, 9, 11, 36, 33, 116, DateTimeKind.Local).AddTicks(9499), null, null, null });

            migrationBuilder.UpdateData(
                table: "SiteInfos",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreationDate", "LinkTelegram", "LinkWhatsApp", "Linkinstagram" },
                values: new object[] { new DateTime(2023, 7, 9, 11, 36, 33, 116, DateTimeKind.Local).AddTicks(9558), null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkTelegram",
                table: "SiteInfos");

            migrationBuilder.DropColumn(
                name: "LinkWhatsApp",
                table: "SiteInfos");

            migrationBuilder.DropColumn(
                name: "Linkinstagram",
                table: "SiteInfos");

            migrationBuilder.UpdateData(
                table: "ChartPictures",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2023, 7, 9, 10, 12, 21, 364, DateTimeKind.Local).AddTicks(9658));

            migrationBuilder.UpdateData(
                table: "ChartPictures",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2023, 7, 9, 10, 12, 21, 364, DateTimeKind.Local).AddTicks(9697));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2023, 7, 9, 10, 12, 21, 364, DateTimeKind.Local).AddTicks(9734));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2023, 7, 9, 10, 12, 21, 364, DateTimeKind.Local).AddTicks(9772));

            migrationBuilder.UpdateData(
                table: "SiteInfos",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2023, 7, 9, 10, 12, 21, 364, DateTimeKind.Local).AddTicks(9451));

            migrationBuilder.UpdateData(
                table: "SiteInfos",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2023, 7, 9, 10, 12, 21, 364, DateTimeKind.Local).AddTicks(9515));
        }
    }
}
