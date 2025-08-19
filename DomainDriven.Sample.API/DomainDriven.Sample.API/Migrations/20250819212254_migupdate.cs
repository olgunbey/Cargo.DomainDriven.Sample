using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DomainDriven.Sample.API.Migrations
{
    /// <inheritdoc />
    public partial class migupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserInformation");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "CustomerReadModel",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "Mail",
                table: "CustomerReadModel",
                newName: "Name");

            migrationBuilder.AddColumn<bool>(
                name: "Gender",
                table: "CustomerReadModel",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "CustomerReadModel");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "CustomerReadModel",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "CustomerReadModel",
                newName: "Mail");

            migrationBuilder.CreateTable(
                name: "UserInformation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Gender = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    UserCredentialsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInformation", x => x.Id);
                });
        }
    }
}
