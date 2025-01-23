using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LegalexAccount.DAL.Migrations
{
    public partial class RenamedToPhoneNumberInUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Specialists",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Clients",
                newName: "PhoneNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Specialists",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Clients",
                newName: "Phone");
        }
    }
}
