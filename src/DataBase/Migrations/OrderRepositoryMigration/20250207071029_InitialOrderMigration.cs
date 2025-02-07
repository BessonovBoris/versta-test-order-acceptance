using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataBase.Migrations
{
    /// <inheritdoc />
    public partial class InitialOrderMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    SenderCity = table.Column<string>(type: "text", nullable: true),
                    SenderAddress = table.Column<string>(type: "text", nullable: true),
                    ReceiverCity = table.Column<string>(type: "text", nullable: true),
                    ReceiverAddress = table.Column<string>(type: "text", nullable: true),
                    CargoWeightKg = table.Column<double>(type: "double precision", nullable: false),
                    PickupDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CargoWeightKg", "PickupDate", "ReceiverAddress", "ReceiverCity", "SenderAddress", "SenderCity", "UserId" },
                values: new object[,]
                {
                    { 1, 0.5, new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), "Popova, 5", "Moscow", "Kolmogorov, 11", "Saint-Petersburg", 1 },
                    { 2, 0.5, new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), "Kronverskiy, 10", "Voronezh", "Kolmogorov, 11", "Saint-Petersburg", 1 },
                    { 3, 1.0, new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), "Tutova, 1", "Saint-Petersburg", "Petrushka, 5", "Novgorod", 3 },
                    { 4, 1.2, new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), "Tamova, 9", "Norilsk", "Retrogradka, 90", "Tula", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
