using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TestingApp.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    MobileNo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Department = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    UnitId = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Address1 = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Address2 = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
