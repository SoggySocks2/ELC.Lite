using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELC.Lite.CoreApp.Infrastucture.Migrations.CoreDb
{
    /// <inheritdoc />
    public partial class AddLeadTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Budget = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    Forenames = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Postcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentVehicleMake = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentVehicleModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentVehicleYear = table.Column<int>(type: "int", nullable: true),
                    InterestedInVehicleMake = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InterestedInVehicleModel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leads", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Leads");
        }
    }
}
