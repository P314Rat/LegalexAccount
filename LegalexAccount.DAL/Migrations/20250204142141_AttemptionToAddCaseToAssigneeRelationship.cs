using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LegalexAccount.DAL.Migrations
{
    public partial class AttemptionToAddCaseToAssigneeRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Clients_CustomerId",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Specialists_AssigneeId",
                table: "Cases");

            migrationBuilder.DropIndex(
                name: "IX_Cases_AssigneeId",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "AssigneeId",
                table: "Cases");

            migrationBuilder.CreateTable(
                name: "CaseSpecialist",
                columns: table => new
                {
                    AssigneesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CasesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseSpecialist", x => new { x.AssigneesId, x.CasesId });
                    table.ForeignKey(
                        name: "FK_CaseSpecialist_Cases_CasesId",
                        column: x => x.CasesId,
                        principalTable: "Cases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaseSpecialist_Specialists_AssigneesId",
                        column: x => x.AssigneesId,
                        principalTable: "Specialists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaseSpecialist_CasesId",
                table: "CaseSpecialist",
                column: "CasesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Clients_CustomerId",
                table: "Cases",
                column: "CustomerId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Clients_CustomerId",
                table: "Cases");

            migrationBuilder.DropTable(
                name: "CaseSpecialist");

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
                name: "FK_Cases_Clients_CustomerId",
                table: "Cases",
                column: "CustomerId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Specialists_AssigneeId",
                table: "Cases",
                column: "AssigneeId",
                principalTable: "Specialists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
