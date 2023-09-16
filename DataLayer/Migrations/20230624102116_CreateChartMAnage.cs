using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class CreateChartMAnage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChartDesigns",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PictureAlt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PictureTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameFamily = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SideCompany = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    MetaDescription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IsRemove = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChartDesigns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChartPictures",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PictureAlt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PictureTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChartPictures", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ChartPictures",
                columns: new[] { "Id", "CreationDate", "Picture", "PictureAlt", "PictureTitle" },
                values: new object[] { 1L, new DateTime(2023, 6, 24, 13, 51, 16, 219, DateTimeKind.Local).AddTicks(7297), "", "", "" });

            migrationBuilder.UpdateData(
                table: "SiteInfos",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2023, 6, 24, 13, 51, 16, 219, DateTimeKind.Local).AddTicks(6989));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChartDesigns");

            migrationBuilder.DropTable(
                name: "ChartPictures");

            migrationBuilder.UpdateData(
                table: "SiteInfos",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2023, 6, 22, 13, 41, 11, 988, DateTimeKind.Local).AddTicks(4523));
        }
    }
}
