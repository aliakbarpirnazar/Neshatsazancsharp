using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class UpdatepodcastTBL1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VideoTitle",
                table: "Podcasts",
                newName: "PictureTitle");

            migrationBuilder.RenameColumn(
                name: "VideoAlt",
                table: "Podcasts",
                newName: "PictureAlt");

            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                table: "SlideHeaders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Podcasts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ChartPictures",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2023, 7, 15, 12, 25, 43, 54, DateTimeKind.Local).AddTicks(4722));

            migrationBuilder.UpdateData(
                table: "ChartPictures",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2023, 7, 15, 12, 25, 43, 54, DateTimeKind.Local).AddTicks(4754));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2023, 7, 15, 12, 25, 43, 54, DateTimeKind.Local).AddTicks(4789));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2023, 7, 15, 12, 25, 43, 54, DateTimeKind.Local).AddTicks(4825));

            migrationBuilder.UpdateData(
                table: "SiteInfos",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2023, 7, 15, 12, 25, 43, 54, DateTimeKind.Local).AddTicks(4611));

            migrationBuilder.UpdateData(
                table: "SiteInfos",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2023, 7, 15, 12, 25, 43, 54, DateTimeKind.Local).AddTicks(4680));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Podcasts");

            migrationBuilder.RenameColumn(
                name: "PictureTitle",
                table: "Podcasts",
                newName: "VideoTitle");

            migrationBuilder.RenameColumn(
                name: "PictureAlt",
                table: "Podcasts",
                newName: "VideoAlt");

            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                table: "SlideHeaders",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "ChartPictures",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2023, 7, 10, 9, 46, 27, 252, DateTimeKind.Local).AddTicks(1250));

            migrationBuilder.UpdateData(
                table: "ChartPictures",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2023, 7, 10, 9, 46, 27, 252, DateTimeKind.Local).AddTicks(1271));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2023, 7, 10, 9, 46, 27, 252, DateTimeKind.Local).AddTicks(1293));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2023, 7, 10, 9, 46, 27, 252, DateTimeKind.Local).AddTicks(1312));

            migrationBuilder.UpdateData(
                table: "SiteInfos",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2023, 7, 10, 9, 46, 27, 252, DateTimeKind.Local).AddTicks(1177));

            migrationBuilder.UpdateData(
                table: "SiteInfos",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2023, 7, 10, 9, 46, 27, 252, DateTimeKind.Local).AddTicks(1224));
        }
    }
}
