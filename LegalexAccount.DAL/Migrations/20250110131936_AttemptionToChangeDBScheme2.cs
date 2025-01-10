using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LegalexAccount.DAL.Migrations
{
    public partial class AttemptionToChangeDBScheme2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Clients_ClientId",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Specialists_SpecialistId",
                table: "Cases");

            migrationBuilder.DropIndex(
                name: "IX_Cases_ClientId",
                table: "Cases");

            migrationBuilder.DropIndex(
                name: "IX_Cases_SpecialistId",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "SpecialistId",
                table: "Cases");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "Cases",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SpecialistId",
                table: "Cases",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cases_ClientId",
                table: "Cases",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_SpecialistId",
                table: "Cases",
                column: "SpecialistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Clients_ClientId",
                table: "Cases",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Specialists_SpecialistId",
                table: "Cases",
                column: "SpecialistId",
                principalTable: "Specialists",
                principalColumn: "Id");
        }
    }
}
