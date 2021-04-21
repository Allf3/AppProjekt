using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class initdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Measurements",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Humidity = table.Column<float>(type: "real", nullable: false),
                    Temperatur = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurements", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "ID", "Date", "Humidity", "Temperatur" },
                values: new object[] { new Guid("c56d122a-3f44-4b2e-9ead-512ddfe51adc"), new DateTime(2021, 4, 21, 13, 43, 29, 510, DateTimeKind.Local).AddTicks(2355), 0f, 24f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Measurements");
        }
    }
}
