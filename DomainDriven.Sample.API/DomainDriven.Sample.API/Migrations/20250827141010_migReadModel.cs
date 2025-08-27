using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DomainDriven.Sample.API.Migrations
{
    /// <inheritdoc />
    public partial class migReadModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderStatus",
                table: "OrderProductReadModel",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderStatus",
                table: "OrderProductReadModel");
        }
    }
}
