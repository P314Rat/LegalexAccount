using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LegalexAccount.DAL.Migrations
{
    public partial class RefactoredOfClientEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Specialists_AssigneeId",
                table: "Cases");

            migrationBuilder.DropIndex(
                name: "IX_Cases_AssigneeId",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "AssigneeId",
                table: "Cases");

            migrationBuilder.RenameColumn(
                name: "PayerAccountNumber",
                table: "LegalEntities",
                newName: "Powers");

            migrationBuilder.RenameColumn(
                name: "LegalForm",
                table: "LegalEntities",
                newName: "LegalID");

            migrationBuilder.RenameColumn(
                name: "GroundsForAsk",
                table: "LegalEntities",
                newName: "BankAddress");

            migrationBuilder.RenameColumn(
                name: "ActualAddress",
                table: "LegalEntities",
                newName: "PostalAddress");

            migrationBuilder.AddColumn<int>(
                name: "CaseId",
                table: "Specialists",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ResidentialAddress",
                table: "Individuals",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Cases",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "EstimatedDaysToEnd",
                table: "Cases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Cases",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Specialists_CaseId",
                table: "Specialists",
                column: "CaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Specialists_Cases_CaseId",
                table: "Specialists",
                column: "CaseId",
                principalTable: "Cases",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Specialists_Cases_CaseId",
                table: "Specialists");

            migrationBuilder.DropIndex(
                name: "IX_Specialists_CaseId",
                table: "Specialists");

            migrationBuilder.DropColumn(
                name: "CaseId",
                table: "Specialists");

            migrationBuilder.DropColumn(
                name: "EstimatedDaysToEnd",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Cases");

            migrationBuilder.RenameColumn(
                name: "Powers",
                table: "LegalEntities",
                newName: "PayerAccountNumber");

            migrationBuilder.RenameColumn(
                name: "PostalAddress",
                table: "LegalEntities",
                newName: "ActualAddress");

            migrationBuilder.RenameColumn(
                name: "LegalID",
                table: "LegalEntities",
                newName: "LegalForm");

            migrationBuilder.RenameColumn(
                name: "BankAddress",
                table: "LegalEntities",
                newName: "GroundsForAsk");

            migrationBuilder.AlterColumn<string>(
                name: "ResidentialAddress",
                table: "Individuals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Cases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AssigneeId",
                table: "Cases",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Cases_AssigneeId",
                table: "Cases",
                column: "AssigneeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Specialists_AssigneeId",
                table: "Cases",
                column: "AssigneeId",
                principalTable: "Specialists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
