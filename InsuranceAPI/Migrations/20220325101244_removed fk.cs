using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsuranceAPI.Migrations
{
    public partial class removedfk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Customers_customer_id",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_customer_id",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "customer_id",
                table: "Cars");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "customer_id",
                table: "Cars",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Cars_customer_id",
                table: "Cars",
                column: "customer_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Customers_customer_id",
                table: "Cars",
                column: "customer_id",
                principalTable: "Customers",
                principalColumn: "customer_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
