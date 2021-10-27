using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyConverter.DataAccess.Migrations
{
    public partial class ConversionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conversion",
                columns: table => new
                {
                    ConversionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BaseSymbol = table.Column<int>(type: "int", nullable: false),
                    TargetSymbol = table.Column<int>(type: "int", nullable: false),
                    BaseValue = table.Column<double>(type: "float", nullable: false),
                    ExchangeRate = table.Column<double>(type: "float", nullable: false),
                    ConvertedValue = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversion", x => x.ConversionId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conversion_ConversionId",
                table: "Conversion",
                column: "ConversionId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conversion");
        }
    }
}
