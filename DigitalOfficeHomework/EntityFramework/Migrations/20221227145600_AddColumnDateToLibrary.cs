using System;
using DigitalOfficeHomework.EntityFramework.DbConfig;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalOfficeHW2.EntityFramework;

[DbContext(typeof(LibraryDbContext))]
[Migration("20221227145600_AddColumnDateToLybrary")]
public class AddColumnDateToLybrary : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<DateTime>(
            name: "FoundationDate",
            table: "Libraries",
            nullable: false,
            defaultValue: DateTime.Now);
    }
    
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable("Libraries");
    }
}

