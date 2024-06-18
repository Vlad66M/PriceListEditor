using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PriceListEditor.Migrations
{
    /// <inheritdoc />
    public partial class AddPriceListIdToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PriceListId",
                table: "Products",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_PriceListId",
                table: "Products",
                column: "PriceListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_PriceLists_PriceListId",
                table: "Products",
                column: "PriceListId",
                principalTable: "PriceLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_PriceLists_PriceListId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_PriceListId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PriceListId",
                table: "Products");
        }
    }
}
