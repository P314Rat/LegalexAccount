using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LegalexAccount.DAL.Migrations
{
    public partial class changEefStrategy8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Legals_Client_Id",
                table: "Legals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Legals",
                table: "Legals");

            migrationBuilder.RenameTable(
                name: "Legals",
                newName: "LegalEntities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LegalEntities",
                table: "LegalEntities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LegalEntities_Client_Id",
                table: "LegalEntities",
                column: "Id",
                principalTable: "Client",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LegalEntities_Client_Id",
                table: "LegalEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LegalEntities",
                table: "LegalEntities");

            migrationBuilder.RenameTable(
                name: "LegalEntities",
                newName: "Legals");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Legals",
                table: "Legals",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Legals_Client_Id",
                table: "Legals",
                column: "Id",
                principalTable: "Client",
                principalColumn: "Id");
        }
    }
}
