using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OT.Assessment.App.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Theme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProviderName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProviderName1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Games_Providers_ProviderName",
                        column: x => x.ProviderName,
                        principalTable: "Providers",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_Games_Providers_ProviderName1",
                        column: x => x.ProviderName1,
                        principalTable: "Providers",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateTable(
                name: "CasinoWagers",
                columns: table => new
                {
                    WagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Theme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Provider = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExternalReferenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfBets = table.Column<int>(type: "int", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SessionData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<long>(type: "bigint", nullable: false),
                    PlayerAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GameProviderName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CasinoWagers", x => x.WagerId);
                    table.ForeignKey(
                        name: "FK_CasinoWagers_Games_GameName",
                        column: x => x.GameName,
                        principalTable: "Games",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CasinoWagers_Players_PlayerAccountId",
                        column: x => x.PlayerAccountId,
                        principalTable: "Players",
                        principalColumn: "AccountId");
                    table.ForeignKey(
                        name: "FK_CasinoWagers_Providers_GameProviderName",
                        column: x => x.GameProviderName,
                        principalTable: "Providers",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CasinoWagers_GameName",
                table: "CasinoWagers",
                column: "GameName");

            migrationBuilder.CreateIndex(
                name: "IX_CasinoWagers_GameProviderName",
                table: "CasinoWagers",
                column: "GameProviderName");

            migrationBuilder.CreateIndex(
                name: "IX_CasinoWagers_PlayerAccountId",
                table: "CasinoWagers",
                column: "PlayerAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_ProviderName",
                table: "Games",
                column: "ProviderName");

            migrationBuilder.CreateIndex(
                name: "IX_Games_ProviderName1",
                table: "Games",
                column: "ProviderName1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CasinoWagers");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Providers");
        }
    }
}
