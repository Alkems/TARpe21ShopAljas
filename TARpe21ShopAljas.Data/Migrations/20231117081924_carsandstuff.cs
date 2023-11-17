using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TARpe21ShopAljas.Data.Migrations
{
    public partial class carsandstuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CarId",
                table: "FilesToApi",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Transmission = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriveTrain = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Horsepower = table.Column<int>(type: "int", nullable: false),
                    Previously_Owned = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZeroToSixty = table.Column<int>(type: "int", nullable: false),
                    FuelType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilesToApi_CarId",
                table: "FilesToApi",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_FilesToApi_Cars_CarId",
                table: "FilesToApi",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilesToApi_Cars_CarId",
                table: "FilesToApi");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_FilesToApi_CarId",
                table: "FilesToApi");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "FilesToApi");
        }
    }
}
