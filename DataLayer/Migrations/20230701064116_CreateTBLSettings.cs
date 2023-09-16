using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class CreateTBLSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SiteDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SiteKeys = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogoAlt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogoTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "ChartPictures",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2023, 7, 1, 10, 11, 16, 607, DateTimeKind.Local).AddTicks(4994));

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreationDate", "Icon", "Logo", "LogoAlt", "LogoTitle", "SiteDesc", "SiteKeys", "SiteName" },
                values: new object[] { 1L, new DateTime(2023, 7, 1, 10, 11, 16, 607, DateTimeKind.Local).AddTicks(5045), "", "", "", "", "", "", "" });

            migrationBuilder.UpdateData(
                table: "SiteInfos",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2023, 7, 1, 10, 11, 16, 607, DateTimeKind.Local).AddTicks(4324));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.UpdateData(
                table: "ChartPictures",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2023, 7, 1, 10, 2, 57, 780, DateTimeKind.Local).AddTicks(9205));

            migrationBuilder.UpdateData(
                table: "SiteInfos",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2023, 7, 1, 10, 2, 57, 780, DateTimeKind.Local).AddTicks(8939));
        }
    }
}
