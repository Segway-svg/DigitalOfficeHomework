using System;
using DigitalOfficeHomework.EntityFramework.DbConfig;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalOfficeHW2.EntityFramework;

[DbContext(typeof(LibraryDbContext))]
[Migration("20221227135200_InitialCreate")]
public class InitialCreate : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Libraries",
            columns: table => new
            {
                Id = table.Column<Guid>(nullable: false, type: "uniqueidentifier"),
                Name = table.Column<string>(nullable: false),
                Address = table.Column<string>(nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Libraries", l => l.Id);
            }
        );

        migrationBuilder.CreateTable(
            name: "Readers",
            columns: table => new
            {
                Id = table.Column<Guid>(nullable: false),
                Name = table.Column<string>(nullable: true),
                LibraryCard = table.Column<int>(nullable: false),
                LibraryId = table.Column<Guid>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Readers", l => l.Id);
            }
        );
    }
    
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable("Libraries");
        migrationBuilder.DropTable("Readers");
    }
}