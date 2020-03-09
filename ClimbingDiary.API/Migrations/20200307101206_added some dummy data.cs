using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClimbingDiary.API.Migrations
{
    public partial class addedsomedummydata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "Author", "Description", "Grade", "Name", "SectorId" },
                values: new object[] { new Guid("29b84dca-3d64-4987-be20-52f5f3f4ba19"), "Jakistam", "Ładny komin", "VI+", "Przez komin", new Guid("17612c45-d23a-4f71-9bef-c6fb0c0a6a0e") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: new Guid("29b84dca-3d64-4987-be20-52f5f3f4ba19"));
        }
    }
}
