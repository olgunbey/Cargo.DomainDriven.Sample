using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DomainDriven.Sample.API.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Order",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "CustomerReadModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    EmployeeId = table.Column<int>(type: "integer", nullable: false),
                    CustomerReadModel_FirstName = table.Column<string>(type: "text", nullable: false),
                    CustomerReadModel_LastName = table.Column<string>(type: "text", nullable: false),
                    CustomerReadModel_PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    CustomerReadModel_CurrentCityName = table.Column<string>(type: "text", nullable: false),
                    CustomerReadModel_CurrentDistrictName = table.Column<string>(type: "text", nullable: false),
                    CustomerReadModel_CurrentDetail = table.Column<string>(type: "text", nullable: false),
                    TargetLocationModel_CityName = table.Column<string>(type: "text", nullable: false),
                    TargetLocationModel_DistrictName = table.Column<string>(type: "text", nullable: false),
                    TargetLocationModel_Detail = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerReadModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderChooseEmployee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    EmployeeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderChooseEmployee", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerReadModel");

            migrationBuilder.DropTable(
                name: "OrderChooseEmployee");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Order");
        }
    }
}
