using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LegalexAccount.DAL.Migrations
{
    public partial class changEefStrategy12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "AssigneeId",
                table: "Cases",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cases_AssigneeId",
                table: "Cases",
                column: "AssigneeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Specialists_AssigneeId",
                table: "Cases",
                column: "AssigneeId",
                principalTable: "Specialists",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "CaseId",
                table: "Specialists",
                type: "int",
                nullable: true);

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
    }
}
