﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InventoryManager.Migrations
{
    /// <inheritdoc />
    public partial class AddedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ProductCategoryId", "CategoryName", "Description" },
                values: new object[,]
                {
                    { "C001", "Fruit", "Fresh fruits" },
                    { "C002", "Vegetables", "Fresh vegetables" },
                    { "C003", "Dairy", "Dairy products" },
                    { "C004", "Beverages", "Drinks and beverages" },
                    { "C005", "Snacks", "Packaged snacks" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "ImageUrl", "ProductCategoryId", "ProductName", "ProductPrice", "ProductQuantity", "SupplierId" },
                values: new object[,]
                {
                    { "P001", null, "Images\\Apple.jfif", "C001", "Apple", 2.5, 0, "S001" },
                    { "P002", null, null, "C001", "Banana", 1.8, 0, "S002" },
                    { "P003", null, null, "C002", "Carrot", 0.5, 0, "S003" },
                    { "P004", null, null, "C002", "Broccoli", 1.2, 0, "S004" },
                    { "P005", null, null, "C003", "Milk", 1.0, 0, "S005" },
                    { "P006", null, "Images\\Cheese1.jfif", "C003", "Cheese", 3.0, 0, "S006" },
                    { "P007", null, null, "C004", "Soda", 1.5, 0, "S007" },
                    { "P008", null, null, "C004", "Orange Juice", 2.0, 0, "S008" },
                    { "P009", null, null, "C005", "Chips", 1.0, 0, "S009" },
                    { "P010", null, null, "C005", "Chocolate", 1.8, 0, "S010" }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "SupplierId", "SupplierAddress", "SupplierContact", "SupplierName" },
                values: new object[,]
                {
                    { "S001", "Pimpri-Chinchwad", "1234567890", "Rajesh Yadav" },
                    { "S002", "Baner, Pune", "9876543210", "Suresh Gupta" },
                    { "S003", "Hinjewadi, Pune", "9123456789", "Meera Sharma" },
                    { "S004", "Kothrud, Pune", "9988776655", "Anil Kumar" },
                    { "S005", "Viman Nagar, Pune", "9876123450", "Sunita Verma" },
                    { "S006", "Wakad, Pune", "9765432198", "Prakash Patel" },
                    { "S007", "Aundh, Pune", "8888999944", "Arjun Desai" },
                    { "S008", "Hadapsar, Pune", "9988001122", "Kavita Joshi" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ProductCategoryId",
                keyValue: "C001");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ProductCategoryId",
                keyValue: "C002");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ProductCategoryId",
                keyValue: "C003");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ProductCategoryId",
                keyValue: "C004");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ProductCategoryId",
                keyValue: "C005");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "P001");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "P002");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "P003");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "P004");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "P005");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "P006");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "P007");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "P008");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "P009");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "P010");

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: "S001");

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: "S002");

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: "S003");

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: "S004");

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: "S005");

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: "S006");

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: "S007");

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: "S008");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
