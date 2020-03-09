using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClimbingDiary.API.Migrations
{
    public partial class DescriptionChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutMe",
                table: "Climbers");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Climbers",
                maxLength: 500,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Climbers",
                keyColumn: "Id",
                keyValue: new Guid("59b94dca-3d64-4987-be20-52f5f3f4ba19"),
                column: "Description",
                value: "Eluwina");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Climbers");

            migrationBuilder.AddColumn<string>(
                name: "AboutMe",
                table: "Climbers",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Climbers",
                keyColumn: "Id",
                keyValue: new Guid("59b94dca-3d64-4987-be20-52f5f3f4ba19"),
                column: "AboutMe",
                value: "Eluwina");
        }
    }
}
