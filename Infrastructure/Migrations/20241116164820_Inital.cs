using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Inital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArticleDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticleOfferItem",
                columns: table => new
                {
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    OfferId = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleOfferItem", x => new { x.ArticleId, x.OfferId });
                    table.ForeignKey(
                        name: "FK_ArticleOfferItem_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleOfferItem_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "ArticleDescription", "ArticleName", "Price" },
                values: new object[,]
                {
                    { 1, "desc1", "item1", 10m },
                    { 2, "desc1", "item2", 22m },
                    { 3, "desc1", "item3", 3m },
                    { 4, "desc1", "item4", 40m },
                    { 5, "desc1", "item5", 52m },
                    { 6, "desc1", "item6", 62m },
                    { 7, "desc1", "item7", 17m },
                    { 8, "desc1", "item8", 28m },
                    { 9, "desc1", "item9", 39m },
                    { 10, "desc1", "item10", 10m },
                    { 11, "desc1", "item11", 11m },
                    { 12, "desc1", "item12", 1m },
                    { 13, "desc1", "item13", 21m },
                    { 14, "desc1", "item14", 22m },
                    { 15, "desc1", "item15", 13m },
                    { 16, "desc1", "item16", 100m },
                    { 17, "desc1", "item17", 114m },
                    { 18, "desc1", "item18", 13m },
                    { 19, "desc1", "item19", 221m },
                    { 20, "desc1", "item20", 111m }
                });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "Date" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2024, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2024, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2024, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2024, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2024, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2024, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(2024, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, new DateTime(2024, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, new DateTime(2024, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, new DateTime(2024, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, new DateTime(2024, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, new DateTime(2024, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, new DateTime(2024, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, new DateTime(2024, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, new DateTime(2024, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "ArticleOfferItem",
                columns: new[] { "ArticleId", "OfferId", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, 2m, 10m },
                    { 1, 2, 3m, 10m },
                    { 1, 5, 3m, 10m },
                    { 1, 6, 3m, 10m },
                    { 1, 10, 3m, 10m },
                    { 2, 1, 3m, 10m },
                    { 2, 4, 3m, 10m },
                    { 2, 19, 3m, 10m },
                    { 3, 7, 3m, 10m },
                    { 4, 1, 4m, 10m },
                    { 4, 2, 3m, 10m },
                    { 4, 6, 3m, 10m },
                    { 4, 14, 11m, 10m },
                    { 4, 18, 3m, 10m },
                    { 5, 8, 3m, 10m },
                    { 5, 14, 3m, 10m },
                    { 6, 13, 34m, 10m },
                    { 6, 19, 3m, 10m },
                    { 7, 1, 4m, 10m },
                    { 7, 4, 3m, 10m },
                    { 7, 19, 3m, 10m },
                    { 8, 1, 1m, 10m },
                    { 8, 15, 3m, 10m },
                    { 10, 9, 32m, 10m },
                    { 10, 20, 3m, 10m },
                    { 11, 11, 33m, 10m },
                    { 11, 19, 3m, 10m },
                    { 12, 12, 3m, 10m },
                    { 12, 14, 4m, 10m },
                    { 12, 19, 3m, 10m },
                    { 13, 2, 3m, 10m },
                    { 14, 19, 3m, 10m },
                    { 15, 1, 3m, 10m },
                    { 15, 3, 3m, 10m },
                    { 15, 19, 3m, 10m },
                    { 18, 1, 3m, 10m },
                    { 18, 10, 3m, 10m },
                    { 18, 19, 3m, 10m },
                    { 19, 16, 3m, 10m },
                    { 19, 17, 3m, 10m },
                    { 19, 19, 3m, 10m },
                    { 20, 1, 2m, 10m },
                    { 20, 19, 3m, 10m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleOfferItem_OfferId",
                table: "ArticleOfferItem",
                column: "OfferId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleOfferItem");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Offers");
        }
    }
}
