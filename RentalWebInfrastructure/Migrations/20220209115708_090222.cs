using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalWebInfrastructure.Migrations
{
    public partial class _090222 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "ProductReviews",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReviewBy",
                table: "ProductReviews",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "ProductReviews",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReturnDate",
                table: "CartItems",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviews_UserId",
                table: "ProductReviews",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductReviews_Users_UserId",
                table: "ProductReviews",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductReviews_Users_UserId",
                table: "ProductReviews");

            migrationBuilder.DropIndex(
                name: "IX_ProductReviews_UserId",
                table: "ProductReviews");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "ProductReviews");

            migrationBuilder.DropColumn(
                name: "ReviewBy",
                table: "ProductReviews");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ProductReviews");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReturnDate",
                table: "CartItems",
                type: "datetime",
                nullable: false,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime");
        }
    }
}
