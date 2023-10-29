using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eComShop.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class commAttadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "tblProducts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "tblProducts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "tblOrders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "tblOrders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "tblOrderItems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "tblOrderItems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "tblCustomers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "tblCustomers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "tblCategories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "tblCategories",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "tblProducts");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "tblProducts");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "tblOrders");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "tblOrders");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "tblOrderItems");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "tblOrderItems");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "tblCustomers");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "tblCustomers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "tblCategories");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "tblCategories");
        }
    }
}
