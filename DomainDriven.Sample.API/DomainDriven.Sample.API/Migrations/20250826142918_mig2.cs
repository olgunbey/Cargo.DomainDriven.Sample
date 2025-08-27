using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DomainDriven.Sample.API.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderProductRealModel",
                table: "OrderProductRealModel");

            migrationBuilder.RenameTable(
                name: "OrderProductRealModel",
                newName: "OrderProductReadModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderProductReadModel",
                table: "OrderProductReadModel",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderProductReadModel",
                table: "OrderProductReadModel");

            migrationBuilder.RenameTable(
                name: "OrderProductReadModel",
                newName: "OrderProductRealModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderProductRealModel",
                table: "OrderProductRealModel",
                column: "OrderId");
        }
    }
}
