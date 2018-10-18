using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace chefs_dishes.Migrations
{
    public partial class YourMigrationName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chef",
                columns: table => new
                {
                    ChefId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    DOB = table.Column<DateTime>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    first_name = table.Column<string>(nullable: false),
                    last_name = table.Column<string>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chef", x => x.ChefId);
                });

            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    DishesId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Calories = table.Column<int>(nullable: false),
                    Chef = table.Column<string>(nullable: false),
                    ChefId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Tastiness = table.Column<int>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.DishesId);
                    table.ForeignKey(
                        name: "FK_Dishes_Chef_ChefId",
                        column: x => x.ChefId,
                        principalTable: "Chef",
                        principalColumn: "ChefId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_ChefId",
                table: "Dishes",
                column: "ChefId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "Chef");
        }
    }
}
