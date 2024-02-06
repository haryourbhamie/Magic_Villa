using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddHouseTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "houses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseNumber = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sqft = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_houses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "houses",
                columns: new[] { "Id", "Address", "CreatedTime", "HouseNumber", "Name", "Sqft", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, "Aduragbemi", new DateTime(2024, 2, 6, 13, 4, 6, 17, DateTimeKind.Local).AddTicks(4937), 1, "Pool View", 3000, new DateTime(2024, 2, 6, 13, 4, 6, 17, DateTimeKind.Local).AddTicks(4951) },
                    { 2, "Yenusi", new DateTime(2024, 2, 6, 13, 4, 6, 17, DateTimeKind.Local).AddTicks(4954), 2, "Beach View", 3200, new DateTime(2024, 2, 6, 13, 4, 6, 17, DateTimeKind.Local).AddTicks(4955) },
                    { 3, "Aderibigbe", new DateTime(2024, 2, 6, 13, 4, 6, 17, DateTimeKind.Local).AddTicks(4958), 3, "Liverpool View", 3500, new DateTime(2024, 2, 6, 13, 4, 6, 17, DateTimeKind.Local).AddTicks(4959) },
                    { 4, "Crescent", new DateTime(2024, 2, 6, 13, 4, 6, 17, DateTimeKind.Local).AddTicks(4961), 4, "Las-Vegas View", 3800, new DateTime(2024, 2, 6, 13, 4, 6, 17, DateTimeKind.Local).AddTicks(4962) },
                    { 5, "Aduragbemi", new DateTime(2024, 2, 6, 13, 4, 6, 17, DateTimeKind.Local).AddTicks(4965), 5, "Alaska View", 4000, new DateTime(2024, 2, 6, 13, 4, 6, 17, DateTimeKind.Local).AddTicks(4966) },
                    { 6, "Aduragbemi", new DateTime(2024, 2, 6, 13, 4, 6, 17, DateTimeKind.Local).AddTicks(4968), 6, "Manchester View", 4500, new DateTime(2024, 2, 6, 13, 4, 6, 17, DateTimeKind.Local).AddTicks(4969) },
                    { 7, "Aduragbemi", new DateTime(2024, 2, 6, 13, 4, 6, 17, DateTimeKind.Local).AddTicks(4971), 7, "Lagoon View", 4600, new DateTime(2024, 2, 6, 13, 4, 6, 17, DateTimeKind.Local).AddTicks(4972) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "houses");
        }
    }
}
