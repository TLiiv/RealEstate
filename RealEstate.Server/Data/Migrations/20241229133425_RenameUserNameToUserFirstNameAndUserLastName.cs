using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstate.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenameUserNameToUserFirstNameAndUserLastName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "User",
                newName: "UserLastName");

            migrationBuilder.AddColumn<string>(
                name: "UserFirstName",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserFirstName",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "UserLastName",
                table: "User",
                newName: "UserName");
        }
    }
}
