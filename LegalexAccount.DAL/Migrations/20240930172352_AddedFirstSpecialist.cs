using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LegalexAccount.DAL.Migrations
{
    public partial class AddedFirstSpecialist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Login",
                table: "Specialists",
                newName: "PasswordSalt");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Orders",
                newName: "ClientType");

            migrationBuilder.RenameColumn(
                name: "Login",
                table: "Clients",
                newName: "PasswordSalt");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Specialists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Specialists");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "PasswordSalt",
                table: "Specialists",
                newName: "Login");

            migrationBuilder.RenameColumn(
                name: "ClientType",
                table: "Orders",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "PasswordSalt",
                table: "Clients",
                newName: "Login");
        }
    }
}
