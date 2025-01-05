using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LegalexAccount.DAL.Migrations
{
    public partial class changEefStrategy2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Client_CustomerId",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Specialists_Cases_CaseId",
                table: "Specialists");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Specialists",
                table: "Specialists");

            migrationBuilder.RenameTable(
                name: "Specialists",
                newName: "User");

            migrationBuilder.RenameIndex(
                name: "IX_Specialists_CaseId",
                table: "User",
                newName: "IX_User_CaseId");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "User",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "User",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "BankAccountNumber",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankAddress",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankIdenticationCode",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankName",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "User",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "IssueDate",
                table: "User",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IssuingAuthority",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegalAddress",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegalID",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrganizationName",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PassportNumber",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PositionHeld",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalAddress",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Powers",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegistrationAddress",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResidentialAddress",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaxIdentificationNumber",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_User_CustomerId",
                table: "Cases",
                column: "CustomerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Cases_CaseId",
                table: "User",
                column: "CaseId",
                principalTable: "Cases",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_User_CustomerId",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Cases_CaseId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropColumn(
                name: "BankAccountNumber",
                table: "User");

            migrationBuilder.DropColumn(
                name: "BankAddress",
                table: "User");

            migrationBuilder.DropColumn(
                name: "BankIdenticationCode",
                table: "User");

            migrationBuilder.DropColumn(
                name: "BankName",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IssueDate",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IssuingAuthority",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LegalAddress",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LegalID",
                table: "User");

            migrationBuilder.DropColumn(
                name: "OrganizationName",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PassportNumber",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PositionHeld",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PostalAddress",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Powers",
                table: "User");

            migrationBuilder.DropColumn(
                name: "RegistrationAddress",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ResidentialAddress",
                table: "User");

            migrationBuilder.DropColumn(
                name: "TaxIdentificationNumber",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Specialists");

            migrationBuilder.RenameIndex(
                name: "IX_User_CaseId",
                table: "Specialists",
                newName: "IX_Specialists_CaseId");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Specialists",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "Specialists",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Specialists",
                table: "Specialists",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankIdenticationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegalAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegalID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PositionHeld = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Powers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IssuingAuthority = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassportNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResidentialAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxIdentificationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Client_CustomerId",
                table: "Cases",
                column: "CustomerId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Specialists_Cases_CaseId",
                table: "Specialists",
                column: "CaseId",
                principalTable: "Cases",
                principalColumn: "Id");
        }
    }
}
