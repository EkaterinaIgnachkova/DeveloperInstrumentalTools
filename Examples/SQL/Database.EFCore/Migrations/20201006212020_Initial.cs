using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Database.EFCore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Blog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryId = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Temperature = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blog_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Code" },
                values: new object[,]
                {
                    { 1, "Freezing" },
                    { 2, "Bracing" },
                    { 3, "Chilly" },
                    { 4, "Cool" },
                    { 5, "Mild" },
                    { 6, "Warm" },
                    { 7, "Balmy" },
                    { 8, "Hot" },
                    { 9, "Sweltering" },
                    { 10, "Scorching" }
                });

            migrationBuilder.InsertData(
                table: "Blog",
                columns: new[] { "Id", "Date", "CategoryId", "Title" },
                values: new object[,]
                {
                    { 3, new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Russian news"},
                    { 1, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Europe news" },
                    { 2, new DateTime(2020, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Japan news" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blog_CategoryId",
                table: "Blog",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blog");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
