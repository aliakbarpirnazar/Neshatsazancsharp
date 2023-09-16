using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class updateTBLarticleCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CanonicalAddress",
                table: "ArticleCategories",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.UpdateData(
                table: "ChartPictures",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2023, 7, 8, 12, 21, 8, 564, DateTimeKind.Local).AddTicks(7561));

            migrationBuilder.UpdateData(
                table: "ChartPictures",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2023, 7, 8, 12, 21, 8, 564, DateTimeKind.Local).AddTicks(7582));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2023, 7, 8, 12, 21, 8, 564, DateTimeKind.Local).AddTicks(7605));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2023, 7, 8, 12, 21, 8, 564, DateTimeKind.Local).AddTicks(7628));

            migrationBuilder.UpdateData(
                table: "SiteInfos",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2023, 7, 8, 12, 21, 8, 564, DateTimeKind.Local).AddTicks(7484));

            migrationBuilder.UpdateData(
                table: "SiteInfos",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2023, 7, 8, 12, 21, 8, 564, DateTimeKind.Local).AddTicks(7531));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CanonicalAddress",
                table: "ArticleCategories",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "ChartPictures",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2023, 7, 7, 15, 12, 58, 784, DateTimeKind.Local).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "ChartPictures",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2023, 7, 7, 15, 12, 58, 784, DateTimeKind.Local).AddTicks(3972));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2023, 7, 7, 15, 12, 58, 784, DateTimeKind.Local).AddTicks(4001));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2023, 7, 7, 15, 12, 58, 784, DateTimeKind.Local).AddTicks(4025));

            migrationBuilder.UpdateData(
                table: "SiteInfos",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2023, 7, 7, 15, 12, 58, 784, DateTimeKind.Local).AddTicks(3830));

            migrationBuilder.UpdateData(
                table: "SiteInfos",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2023, 7, 7, 15, 12, 58, 784, DateTimeKind.Local).AddTicks(3911));
        }
    }
}
