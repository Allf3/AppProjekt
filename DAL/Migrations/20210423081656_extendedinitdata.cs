using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class extendedinitdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "ID",
                keyValue: new Guid("c56d122a-3f44-4b2e-9ead-512ddfe51adc"));

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "ID", "Date", "Humidity", "Temperatur" },
                values: new object[,]
                {
                    { new Guid("bcf947c9-8732-49d5-9538-79efc2098709"), new DateTime(2021, 4, 23, 10, 16, 56, 482, DateTimeKind.Local).AddTicks(310), 0f, 19f },
                    { new Guid("38f92361-cda5-4b75-9517-3470b75bb364"), new DateTime(2021, 4, 23, 10, 16, 58, 484, DateTimeKind.Local).AddTicks(5054), 0f, 19.5f },
                    { new Guid("cf54c57a-359c-47ed-8ddf-80f457bd803c"), new DateTime(2021, 4, 23, 10, 17, 0, 484, DateTimeKind.Local).AddTicks(5099), 0f, 20.5f },
                    { new Guid("f5237d2a-39a7-49e3-b5a8-abd784e0122e"), new DateTime(2021, 4, 23, 10, 17, 4, 484, DateTimeKind.Local).AddTicks(5106), 0f, 20.2f },
                    { new Guid("3de03f70-daab-479c-994f-ff02329d0766"), new DateTime(2021, 4, 23, 10, 17, 6, 484, DateTimeKind.Local).AddTicks(5110), 0f, 20.3f },
                    { new Guid("118183d4-256a-4228-b69a-237066798de7"), new DateTime(2021, 4, 23, 10, 17, 8, 484, DateTimeKind.Local).AddTicks(5114), 0f, 21f },
                    { new Guid("35633c90-548c-4ed9-9a42-06e8797f6fec"), new DateTime(2021, 4, 23, 10, 17, 10, 484, DateTimeKind.Local).AddTicks(5118), 0f, 21.2f },
                    { new Guid("b3806e46-b881-454d-9d49-8ec8b9e48c10"), new DateTime(2021, 4, 23, 10, 17, 12, 484, DateTimeKind.Local).AddTicks(5135), 0f, 21.5f },
                    { new Guid("2151428a-61ae-4cb4-978d-62977fb87237"), new DateTime(2021, 4, 23, 10, 17, 14, 484, DateTimeKind.Local).AddTicks(5139), 0f, 21.3f },
                    { new Guid("e561ed0e-771f-4762-9d82-772e514dd9b9"), new DateTime(2021, 4, 23, 10, 17, 16, 484, DateTimeKind.Local).AddTicks(5143), 0f, 20.9f },
                    { new Guid("30282679-2cd5-469e-8ca4-22668f73bdc3"), new DateTime(2021, 4, 23, 10, 17, 18, 484, DateTimeKind.Local).AddTicks(5147), 0f, 20.8f },
                    { new Guid("81a77806-eb59-447d-bd49-88edec5c8dee"), new DateTime(2021, 4, 23, 10, 17, 20, 484, DateTimeKind.Local).AddTicks(5150), 0f, 21.1f },
                    { new Guid("da27016e-c929-4eb1-ac43-917e79a581e2"), new DateTime(2021, 4, 23, 10, 17, 22, 484, DateTimeKind.Local).AddTicks(5154), 0f, 20.94f },
                    { new Guid("c2f9c76d-faa0-4778-bc65-08f78a96f531"), new DateTime(2021, 4, 23, 10, 17, 24, 484, DateTimeKind.Local).AddTicks(5157), 0f, 20.6f }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "ID",
                keyValue: new Guid("118183d4-256a-4228-b69a-237066798de7"));

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "ID",
                keyValue: new Guid("2151428a-61ae-4cb4-978d-62977fb87237"));

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "ID",
                keyValue: new Guid("30282679-2cd5-469e-8ca4-22668f73bdc3"));

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "ID",
                keyValue: new Guid("35633c90-548c-4ed9-9a42-06e8797f6fec"));

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "ID",
                keyValue: new Guid("38f92361-cda5-4b75-9517-3470b75bb364"));

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "ID",
                keyValue: new Guid("3de03f70-daab-479c-994f-ff02329d0766"));

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "ID",
                keyValue: new Guid("81a77806-eb59-447d-bd49-88edec5c8dee"));

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "ID",
                keyValue: new Guid("b3806e46-b881-454d-9d49-8ec8b9e48c10"));

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "ID",
                keyValue: new Guid("bcf947c9-8732-49d5-9538-79efc2098709"));

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "ID",
                keyValue: new Guid("c2f9c76d-faa0-4778-bc65-08f78a96f531"));

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "ID",
                keyValue: new Guid("cf54c57a-359c-47ed-8ddf-80f457bd803c"));

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "ID",
                keyValue: new Guid("da27016e-c929-4eb1-ac43-917e79a581e2"));

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "ID",
                keyValue: new Guid("e561ed0e-771f-4762-9d82-772e514dd9b9"));

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "ID",
                keyValue: new Guid("f5237d2a-39a7-49e3-b5a8-abd784e0122e"));

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "ID", "Date", "Humidity", "Temperatur" },
                values: new object[] { new Guid("c56d122a-3f44-4b2e-9ead-512ddfe51adc"), new DateTime(2021, 4, 21, 13, 43, 29, 510, DateTimeKind.Local).AddTicks(2355), 0f, 24f });
        }
    }
}
