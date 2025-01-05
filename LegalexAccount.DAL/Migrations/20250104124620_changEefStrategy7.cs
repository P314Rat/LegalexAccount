using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LegalexAccount.DAL.Migrations
{
    public partial class changEefStrategy7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BankAccountNumber",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "BankAddress",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "BankIdenticationCode",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "BankName",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "IssueDate",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "IssuingAuthority",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "LegalAddress",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "LegalID",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "OrganizationName",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "PassportNumber",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "PositionHeld",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "PostalAddress",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "Powers",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "RegistrationAddress",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "ResidentialAddress",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "TaxIdentificationNumber",
                table: "Client");

            migrationBuilder.CreateTable(
                name: "Individuals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PassportNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssuingAuthority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaxIdentificationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResidentialAddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Individuals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Individuals_Client_Id",
                        column: x => x.Id,
                        principalTable: "Client",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Legals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LegalAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegalID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankIdenticationCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PositionHeld = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Powers = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Legals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Legals_Client_Id",
                        column: x => x.Id,
                        principalTable: "Client",
                        principalColumn: "Id");
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Individuals");

            migrationBuilder.DropTable(
                name: "Legals");

            migrationBuilder.AddColumn<string>(
                name: "BankAccountNumber",
                table: "Client",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankAddress",
                table: "Client",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankIdenticationCode",
                table: "Client",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankName",
                table: "Client",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Client",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Client",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "IssueDate",
                table: "Client",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IssuingAuthority",
                table: "Client",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegalAddress",
                table: "Client",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegalID",
                table: "Client",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrganizationName",
                table: "Client",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PassportNumber",
                table: "Client",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PositionHeld",
                table: "Client",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalAddress",
                table: "Client",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Powers",
                table: "Client",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegistrationAddress",
                table: "Client",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResidentialAddress",
                table: "Client",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaxIdentificationNumber",
                table: "Client",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
