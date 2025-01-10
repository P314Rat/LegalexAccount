using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LegalexAccount.DAL.Migrations
{
    public partial class AttemptionToChangeDBScheme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BankAccountNumber",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "BankAddress",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "BankIdenticationCode",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "BankName",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "IssueDate",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "IssuingAuthority",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "LegalAddress",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "LegalID",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "OrganizationName",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "PassportNumber",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "PositionHeld",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "PostalAddress",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Powers",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "RegistrationAddress",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ResidentialAddress",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "TaxIdentificationNumber",
                table: "Clients");

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
                        name: "FK_Individuals_Clients_Id",
                        column: x => x.Id,
                        principalTable: "Clients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LegalEntities",
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
                    table.PrimaryKey("PK_LegalEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LegalEntities_Clients_Id",
                        column: x => x.Id,
                        principalTable: "Clients",
                        principalColumn: "Id");
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Individuals");

            migrationBuilder.DropTable(
                name: "LegalEntities");

            migrationBuilder.AddColumn<string>(
                name: "BankAccountNumber",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankAddress",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankIdenticationCode",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankName",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Clients",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "IssueDate",
                table: "Clients",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IssuingAuthority",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegalAddress",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegalID",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrganizationName",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PassportNumber",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PositionHeld",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalAddress",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Powers",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegistrationAddress",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResidentialAddress",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaxIdentificationNumber",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
