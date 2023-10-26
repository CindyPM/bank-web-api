using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankData.Migrations
{
    /// <inheritdoc />
    public partial class CreateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CDT",
                columns: table => new
                {
                    IdCDT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Balance = table.Column<int>(type: "int", nullable: false),
                    InterestRate = table.Column<decimal>(type: "decimal(12,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CDT", x => x.IdCDT);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    IdCountry = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.IdCountry);
                });

            migrationBuilder.CreateTable(
                name: "CurrentAccount",
                columns: table => new
                {
                    IdCurrentAccount = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Balance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentAccount", x => x.IdCurrentAccount);
                });

            migrationBuilder.CreateTable(
                name: "SavingsAccount",
                columns: table => new
                {
                    IdSavingsAccount = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Balance = table.Column<int>(type: "int", nullable: false),
                    InterestRate = table.Column<decimal>(type: "decimal(12,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavingsAccount", x => x.IdSavingsAccount);
                });

            migrationBuilder.CreateTable(
                name: "LegalRepresentative",
                columns: table => new
                {
                    IdLegalRepresentative = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    IdentificationType = table.Column<int>(type: "int", nullable: false),
                    IdentificationNumber = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    MobileNumber = table.Column<int>(type: "int", nullable: false),
                    IdCountry = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalRepresentative", x => x.IdLegalRepresentative);
                    table.ForeignKey(
                        name: "FK_LegalRepresentative_Country_IdCountry",
                        column: x => x.IdCountry,
                        principalTable: "Country",
                        principalColumn: "IdCountry",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    IdClient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    IdentificationType = table.Column<int>(type: "int", nullable: false),
                    IdentificationNumber = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    IdLegalRepresentative = table.Column<int>(type: "int", nullable: false),
                    IdSavingsAccount = table.Column<int>(type: "int", nullable: false),
                    IdCurrentAccount = table.Column<int>(type: "int", nullable: false),
                    IdCDT = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.IdClient);
                    table.ForeignKey(
                        name: "FK_Client_CDT_IdCDT",
                        column: x => x.IdCDT,
                        principalTable: "CDT",
                        principalColumn: "IdCDT",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Client_CurrentAccount_IdCurrentAccount",
                        column: x => x.IdCurrentAccount,
                        principalTable: "CurrentAccount",
                        principalColumn: "IdCurrentAccount",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Client_LegalRepresentative_IdLegalRepresentative",
                        column: x => x.IdLegalRepresentative,
                        principalTable: "LegalRepresentative",
                        principalColumn: "IdLegalRepresentative",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Client_SavingsAccount_IdSavingsAccount",
                        column: x => x.IdSavingsAccount,
                        principalTable: "SavingsAccount",
                        principalColumn: "IdSavingsAccount",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_IdCDT",
                table: "Client",
                column: "IdCDT");

            migrationBuilder.CreateIndex(
                name: "IX_Client_IdCurrentAccount",
                table: "Client",
                column: "IdCurrentAccount");

            migrationBuilder.CreateIndex(
                name: "IX_Client_IdLegalRepresentative",
                table: "Client",
                column: "IdLegalRepresentative");

            migrationBuilder.CreateIndex(
                name: "IX_Client_IdSavingsAccount",
                table: "Client",
                column: "IdSavingsAccount");

            migrationBuilder.CreateIndex(
                name: "IX_LegalRepresentative_IdCountry",
                table: "LegalRepresentative",
                column: "IdCountry");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "CDT");

            migrationBuilder.DropTable(
                name: "CurrentAccount");

            migrationBuilder.DropTable(
                name: "LegalRepresentative");

            migrationBuilder.DropTable(
                name: "SavingsAccount");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
