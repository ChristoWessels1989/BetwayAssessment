using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OT.Assessment.App.Migrations
{
    /// <inheritdoc />
    public partial class removedFKlinkfromprovider : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Providers_ProviderName1",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_ProviderName1",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "ProviderName1",
                table: "Games");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProviderName1",
                table: "Games",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_ProviderName1",
                table: "Games",
                column: "ProviderName1");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Providers_ProviderName1",
                table: "Games",
                column: "ProviderName1",
                principalTable: "Providers",
                principalColumn: "Name");
        }
    }
}
