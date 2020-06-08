using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataService.Migrations
{
    public partial class RecStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackageName = table.Column<string>(maxLength: 10, nullable: false),
                    BuyPrice = table.Column<double>(nullable: false),
                    SellPrice = table.Column<double>(nullable: false),
                    Revenue = table.Column<double>(nullable: false),
                    RevenuePercent = table.Column<int>(nullable: false),
                    BuyDate = table.Column<DateTime>(nullable: false),
                    SellDate = table.Column<DateTime>(nullable: false),
                    WaitingDate = table.Column<int>(nullable: false),
                    BuyFrom = table.Column<string>(maxLength: 20, nullable: false),
                    SellTo = table.Column<string>(maxLength: 20, nullable: true),
                    Fee = table.Column<double>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Note = table.Column<string>(maxLength: 100, nullable: true),
                    RecordStatus = table.Column<int>(nullable: false, defaultValue: 1),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(maxLength: 20, nullable: false),
                    PasswordHash = table.Column<string>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<DateTime>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    AmountValue = table.Column<double>(nullable: false),
                    ContactWho = table.Column<string>(maxLength: 50, nullable: false),
                    ContactNumber = table.Column<string>(maxLength: 14, nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    ContractId = table.Column<int>(nullable: true),
                    RecordStatus = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ContractId",
                table: "Transactions",
                column: "ContractId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Contracts");
        }
    }
}
