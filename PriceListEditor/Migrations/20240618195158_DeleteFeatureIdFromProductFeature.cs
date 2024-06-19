using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PriceListEditor.Migrations
{
    /// <inheritdoc />
    public partial class DeleteFeatureIdFromProductFeature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FeatureId",
                table: "ProductFeatures");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FeatureId",
                table: "ProductFeatures",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
