using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DomainDriven.Sample.API.Migrations
{
    /// <inheritdoc />
    public partial class migClientCredentialTableDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "CargoInformation");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EstimateDateTime",
                table: "CargoInformation",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "EstimateDateTime",
                table: "CargoInformation",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "CargoInformation",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
