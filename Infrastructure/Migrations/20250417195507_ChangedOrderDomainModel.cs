using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedOrderDomainModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Service",
                table: "Orders",
                newName: "ServiceType");

            migrationBuilder.AddColumn<DateTime>(
                name: "ArchivedAt",
                table: "Orders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArchivedAt",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ServiceType",
                table: "Orders",
                newName: "Service");
        }
    }
}
