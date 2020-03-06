using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClimbingDiary.API.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Climbers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    SecondName = table.Column<string>(maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTimeOffset>(nullable: false),
                    AboutMe = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Climbers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sectors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Country = table.Column<string>(maxLength: 50, nullable: false),
                    Category = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sectors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Grade = table.Column<string>(maxLength: 50, nullable: false),
                    Author = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    SectorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Routes_Sectors_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Climbers",
                columns: new[] { "Id", "AboutMe", "DateOfBirth", "FirstName", "SecondName" },
                values: new object[] { new Guid("59b94dca-3d64-4987-be20-52f5f3f4ba19"), "Eluwina", new DateTimeOffset(new DateTime(1997, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Michal", "Iksde" });

            migrationBuilder.InsertData(
                table: "Sectors",
                columns: new[] { "Id", "Category", "Country", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("17612c45-d23a-4f71-9bef-c6fb0c0a6a0e"), "Vertical", "Poland", "Rzechowice", "Rzedkowice" },
                    { new Guid("28612c45-d23a-4f71-9bef-c6fb0c0a6a0e"), "Vertical", "Poland", "Mirow", "Mirow" },
                    { new Guid("39612c45-d23a-4f71-9bef-c6fb0c0a6a0e"), "Vertical", "Slovakia", "Sample description", "Sulovskie skaly" }
                });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "Author", "Description", "Grade", "Name", "SectorId" },
                values: new object[] { new Guid("29b94dca-3d64-4987-be20-52f5f3f4ba19"), "Jakistam", "Very nice Keepo", "VI.2", "Magnezjowka", new Guid("17612c45-d23a-4f71-9bef-c6fb0c0a6a0e") });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "Author", "Description", "Grade", "Name", "SectorId" },
                values: new object[] { new Guid("39b94dca-3d64-4987-be20-52f5f3f4ba19"), "Jakistam", "Very nice Keepo", "VI.1", "Najwazniejeszy pierwszy krok", new Guid("28612c45-d23a-4f71-9bef-c6fb0c0a6a0e") });

            migrationBuilder.CreateIndex(
                name: "IX_Routes_SectorId",
                table: "Routes",
                column: "SectorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Climbers");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "Sectors");
        }
    }
}
