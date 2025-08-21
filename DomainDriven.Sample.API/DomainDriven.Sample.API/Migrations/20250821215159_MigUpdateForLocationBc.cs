using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DomainDriven.Sample.API.Migrations
{
    /// <inheritdoc />
    public partial class MigUpdateForLocationBc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CityId",
                table: "OrderProductRealModel");

            migrationBuilder.DropColumn(
                name: "CityName",
                table: "OrderProductRealModel");

            migrationBuilder.DropColumn(
                name: "DistrictName",
                table: "OrderProductRealModel");

            migrationBuilder.RenameColumn(
                name: "DistrictId",
                table: "OrderProductRealModel",
                newName: "CustomerOrderTargetLocationId");

            migrationBuilder.CreateTable(
                name: "CustomerOrderTargetLocation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    CityId = table.Column<Guid>(type: "uuid", nullable: false),
                    DistrictId = table.Column<Guid>(type: "uuid", nullable: false),
                    Detail = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerOrderTargetLocation", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerOrderTargetLocation");

            migrationBuilder.RenameColumn(
                name: "CustomerOrderTargetLocationId",
                table: "OrderProductRealModel",
                newName: "DistrictId");

            migrationBuilder.AddColumn<Guid>(
                name: "CityId",
                table: "OrderProductRealModel",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "CityName",
                table: "OrderProductRealModel",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DistrictName",
                table: "OrderProductRealModel",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
