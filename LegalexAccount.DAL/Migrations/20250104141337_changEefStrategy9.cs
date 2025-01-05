using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LegalexAccount.DAL.Migrations
{
    public partial class changEefStrategy9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Client_CustomerId",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Individuals_Client_Id",
                table: "Individuals");

            migrationBuilder.DropForeignKey(
                name: "FK_LegalEntities_Client_Id",
                table: "LegalEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Client",
                table: "Client");

            migrationBuilder.RenameTable(
                name: "Client",
                newName: "Clients");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Clients_CustomerId",
                table: "Cases",
                column: "CustomerId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Individuals_Clients_Id",
                table: "Individuals",
                column: "Id",
                principalTable: "Clients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LegalEntities_Clients_Id",
                table: "LegalEntities",
                column: "Id",
                principalTable: "Clients",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Clients_CustomerId",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Individuals_Clients_Id",
                table: "Individuals");

            migrationBuilder.DropForeignKey(
                name: "FK_LegalEntities_Clients_Id",
                table: "LegalEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "Client");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Client",
                table: "Client",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Client_CustomerId",
                table: "Cases",
                column: "CustomerId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Individuals_Client_Id",
                table: "Individuals",
                column: "Id",
                principalTable: "Client",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LegalEntities_Client_Id",
                table: "LegalEntities",
                column: "Id",
                principalTable: "Client",
                principalColumn: "Id");
        }
    }
}
