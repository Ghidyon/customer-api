using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Balance = table.Column<decimal>(type: "decimal(38,2)", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "DateOfBirth", "Email", "FullName", "Phone" },
                values: new object[] { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), "583 Wall Dr. Gwynn Oak, MD 21207, USA", new DateTime(2001, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@domain.com", "Zubby Gideon", "08160451288" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "DateOfBirth", "Email", "FullName", "Phone" },
                values: new object[] { new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), "583 Wall Street. Gym Oak, MD 21207, USA", new DateTime(1991, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "seed@domain.com", "Seed Gideon", "015484855" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Balance", "CustomerId", "Number" },
                values: new object[] { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), 50.00m, new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), "1005345781" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Balance", "CustomerId", "Number" },
                values: new object[] { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), 510.99m, new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), "2333323424" });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CustomerId",
                table: "Accounts",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
