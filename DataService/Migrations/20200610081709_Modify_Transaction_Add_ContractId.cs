using Microsoft.EntityFrameworkCore.Migrations;

namespace DataService.Migrations
{
    public partial class Modify_Transaction_Add_ContractId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Contracts_ContractId",
                table: "Transactions");

            migrationBuilder.AlterColumn<int>(
                name: "ContractId",
                table: "Transactions",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Contracts_ContractId",
                table: "Transactions",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Contracts_ContractId",
                table: "Transactions");

            migrationBuilder.AlterColumn<int>(
                name: "ContractId",
                table: "Transactions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Contracts_ContractId",
                table: "Transactions",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
