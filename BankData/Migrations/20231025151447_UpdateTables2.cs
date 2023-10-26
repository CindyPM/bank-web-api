using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankData.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTables2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_CDT_IdCDT",
                table: "Client");

            migrationBuilder.DropForeignKey(
                name: "FK_Client_CurrentAccount_IdCurrentAccount",
                table: "Client");

            migrationBuilder.DropForeignKey(
                name: "FK_Client_LegalRepresentative_IdLegalRepresentative",
                table: "Client");

            migrationBuilder.DropForeignKey(
                name: "FK_Client_SavingsAccount_IdSavingsAccount",
                table: "Client");

            migrationBuilder.AlterColumn<int>(
                name: "IdSavingsAccount",
                table: "Client",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdLegalRepresentative",
                table: "Client",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdCurrentAccount",
                table: "Client",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdCDT",
                table: "Client",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_CDT_IdCDT",
                table: "Client",
                column: "IdCDT",
                principalTable: "CDT",
                principalColumn: "IdCDT");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_CurrentAccount_IdCurrentAccount",
                table: "Client",
                column: "IdCurrentAccount",
                principalTable: "CurrentAccount",
                principalColumn: "IdCurrentAccount");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_LegalRepresentative_IdLegalRepresentative",
                table: "Client",
                column: "IdLegalRepresentative",
                principalTable: "LegalRepresentative",
                principalColumn: "IdLegalRepresentative");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_SavingsAccount_IdSavingsAccount",
                table: "Client",
                column: "IdSavingsAccount",
                principalTable: "SavingsAccount",
                principalColumn: "IdSavingsAccount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_CDT_IdCDT",
                table: "Client");

            migrationBuilder.DropForeignKey(
                name: "FK_Client_CurrentAccount_IdCurrentAccount",
                table: "Client");

            migrationBuilder.DropForeignKey(
                name: "FK_Client_LegalRepresentative_IdLegalRepresentative",
                table: "Client");

            migrationBuilder.DropForeignKey(
                name: "FK_Client_SavingsAccount_IdSavingsAccount",
                table: "Client");

            migrationBuilder.AlterColumn<int>(
                name: "IdSavingsAccount",
                table: "Client",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdLegalRepresentative",
                table: "Client",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdCurrentAccount",
                table: "Client",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdCDT",
                table: "Client",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Client_CDT_IdCDT",
                table: "Client",
                column: "IdCDT",
                principalTable: "CDT",
                principalColumn: "IdCDT",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Client_CurrentAccount_IdCurrentAccount",
                table: "Client",
                column: "IdCurrentAccount",
                principalTable: "CurrentAccount",
                principalColumn: "IdCurrentAccount",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Client_LegalRepresentative_IdLegalRepresentative",
                table: "Client",
                column: "IdLegalRepresentative",
                principalTable: "LegalRepresentative",
                principalColumn: "IdLegalRepresentative",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Client_SavingsAccount_IdSavingsAccount",
                table: "Client",
                column: "IdSavingsAccount",
                principalTable: "SavingsAccount",
                principalColumn: "IdSavingsAccount",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
