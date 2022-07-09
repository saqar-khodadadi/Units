using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.DataAccess.Migrations
{
    public partial class UnitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kind",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kind", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Factor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToValue = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ToBase = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    KindId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Factor_Kind_KindId",
                        column: x => x.KindId,
                        principalTable: "Kind",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Unit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnTitle = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Measurment = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EnMeasurment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FactorId = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Unit_Factor_FactorId",
                        column: x => x.FactorId,
                        principalTable: "Factor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Unit_Unit_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Unit",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Kind",
                columns: new[] { "Id", "Title" },
                values: new object[] { 1, "پایه" });

            migrationBuilder.InsertData(
                table: "Kind",
                columns: new[] { "Id", "Title" },
                values: new object[] { 2, "ضریب دار" });

            migrationBuilder.InsertData(
                table: "Kind",
                columns: new[] { "Id", "Title" },
                values: new object[] { 3, "فرمول دار" });

            migrationBuilder.InsertData(
                table: "Factor",
                columns: new[] { "Id", "KindId", "Title", "ToBase", "ToValue" },
                values: new object[,]
                {
                    { 1, 1, "پایه", "a", "a" },
                    { 2, 2, "کیلو", "a*1000", "a/1000" },
                    { 3, 3, "فارنهایت", "(a − 32) × 5/9", "(a * 9/5) + 32" },
                    { 4, 2, "میلی", "a*0.001", "a/0.001" },
                    { 5, 2, "ثانتی", "a*0.01", "a/0.01" },
                    { 6, 2, "مگا", "a*1000000", "a/1000000" },
                    { 7, 2, "کلوین", "a − 273.15", "a + 273.15" }
                });

            migrationBuilder.InsertData(
                table: "Unit",
                columns: new[] { "Id", "EnMeasurment", "EnTitle", "FactorId", "Measurment", "ParentId", "Symbol", "Title" },
                values: new object[,]
                {
                    { 1, "Length", "Meter", 1, "طول", null, "m", "متر" },
                    { 2, "Mass", "Gram", 1, "جرم", null, "g", "گرم" },
                    { 3, "electric current", "Ampere", 1, "جریان الکترونیکی", null, "A", "آمپر" },
                    { 4, "Time", "Second", 1, "زمان", null, "S", "ثانیه" },
                    { 5, "numeration", "Each", 1, "شمارش", null, "E", "عدد" },
                    { 6, "Temperature", "Celsius", 1, "دما", null, "C", "سلسیوس" }
                });

            migrationBuilder.InsertData(
                table: "Unit",
                columns: new[] { "Id", "EnMeasurment", "EnTitle", "FactorId", "Measurment", "ParentId", "Symbol", "Title" },
                values: new object[,]
                {
                    { 7, "Length", "Milimeter", 4, "طول", 1, "mm", "میلی متر" },
                    { 8, "Length", "Centimeter", 5, "متر", 1, "cm", "ثانتی متر" },
                    { 9, "Length", "Kilometer", 2, "متر", 1, "km", "کیلومتر" },
                    { 10, "Mass", "Milligram", 4, "جرم", 2, "mg", "میلی گرم" },
                    { 11, "Mass", "Kilogram", 2, "جرم", 2, "kg", "کیلوگرم" },
                    { 12, "Mass", "Tonne", 6, "جرم", 2, "ton", "تن" },
                    { 13, "Temperature", "Kelvin", 7, "دما", 6, "K", "کلوین" },
                    { 14, "Temperature", "Fahrenheit", 3, "دما", 6, "F", "فارنهایت" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Factor_KindId",
                table: "Factor",
                column: "KindId");

            migrationBuilder.CreateIndex(
                name: "IX_Unit_FactorId",
                table: "Unit",
                column: "FactorId");

            migrationBuilder.CreateIndex(
                name: "IX_Unit_ParentId",
                table: "Unit",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Unit");

            migrationBuilder.DropTable(
                name: "Factor");

            migrationBuilder.DropTable(
                name: "Kind");
        }
    }
}
