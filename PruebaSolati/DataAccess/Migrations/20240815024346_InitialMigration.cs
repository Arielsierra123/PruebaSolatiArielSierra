using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<int>(type: "integer", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Picture = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Code", "CreationDate", "Name", "Picture", "Price" },
                values: new object[,]
                {
                    { 1, 123, new DateTime(2024, 8, 15, 2, 43, 45, 916, DateTimeKind.Utc).AddTicks(3921), "test1", "string", 123m },
                    { 2, 123, new DateTime(2024, 8, 15, 2, 43, 45, 916, DateTimeKind.Utc).AddTicks(3924), "test2", "string", 123m },
                    { 3, 123, new DateTime(2024, 8, 15, 2, 43, 45, 916, DateTimeKind.Utc).AddTicks(3925), "test3", "string", 123m },
                    { 4, 123, new DateTime(2024, 8, 15, 2, 43, 45, 916, DateTimeKind.Utc).AddTicks(3926), "test4", "string", 123m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
