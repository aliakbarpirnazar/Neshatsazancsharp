using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class CreateLangugeENTOALLTBL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "SlideHeaders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "SiteInfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Podcasts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "NewsSites",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "ChartPictures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "ChartDesigns",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "AskedQuestions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "ArticleCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ChartPictures",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreationDate", "Language" },
                values: new object[] { new DateTime(2023, 7, 2, 14, 6, 44, 983, DateTimeKind.Local).AddTicks(2973), "0" });

            migrationBuilder.InsertData(
                table: "ChartPictures",
                columns: new[] { "Id", "CreationDate", "Language", "Picture", "PictureAlt", "PictureTitle" },
                values: new object[] { 2L, new DateTime(2023, 7, 2, 14, 6, 44, 983, DateTimeKind.Local).AddTicks(2991), "1", "", "", "" });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreationDate", "Language" },
                values: new object[] { new DateTime(2023, 7, 2, 14, 6, 44, 983, DateTimeKind.Local).AddTicks(3010), "0" });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreationDate", "Icon", "Language", "Logo", "LogoAlt", "LogoTitle", "SiteDesc", "SiteKeys", "SiteName" },
                values: new object[] { 2L, new DateTime(2023, 7, 2, 14, 6, 44, 983, DateTimeKind.Local).AddTicks(3031), "", "1", "", "", "", "", "", "" });

            migrationBuilder.UpdateData(
                table: "SiteInfos",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreationDate", "Language" },
                values: new object[] { new DateTime(2023, 7, 2, 14, 6, 44, 983, DateTimeKind.Local).AddTicks(2850), "0" });

            migrationBuilder.InsertData(
                table: "SiteInfos",
                columns: new[] { "Id", "Address", "CreationDate", "Description", "Language", "LinkLocation", "MetaDescription", "MissionCompany", "Picture", "PictureAlt", "PictureTitle", "Qusetion", "ShortDescription", "TelNumber", "TimeRun", "VisionCompany" },
                values: new object[] { 2L, "Qom", new DateTime(2023, 7, 2, 14, 6, 44, 983, DateTimeKind.Local).AddTicks(2947), "", "1", "", "", "", "", "", "", "", "", "", "", "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ChartPictures",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "SiteInfos",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DropColumn(
                name: "Language",
                table: "SlideHeaders");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "SiteInfos");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Podcasts");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "NewsSites");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "ChartPictures");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "ChartDesigns");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "AskedQuestions");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "ArticleCategories");

            migrationBuilder.UpdateData(
                table: "ChartPictures",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2023, 7, 1, 10, 11, 16, 607, DateTimeKind.Local).AddTicks(4994));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2023, 7, 1, 10, 11, 16, 607, DateTimeKind.Local).AddTicks(5045));

            migrationBuilder.UpdateData(
                table: "SiteInfos",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2023, 7, 1, 10, 11, 16, 607, DateTimeKind.Local).AddTicks(4324));
        }
    }
}
