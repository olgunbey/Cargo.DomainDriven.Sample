using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DomainDriven.Sample.API.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderProductReadModel",
                table: "OrderProductReadModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderProductReadModel",
                table: "OrderProductReadModel",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderProductReadModel",
                table: "OrderProductReadModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderProductReadModel",
                table: "OrderProductReadModel",
                column: "OrderId");
        }
    }
}
