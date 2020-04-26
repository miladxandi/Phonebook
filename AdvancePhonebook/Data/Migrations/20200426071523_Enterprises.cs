using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvancePhonebook.Data.Migrations
{
    public partial class Enterprises : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enterprises",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 13,nullable: true),
                    Fax = table.Column<string>(maxLength: 13,nullable: true),
                    Address = table.Column<string>(maxLength: 13,nullable: true),
                    PostalCode = table.Column<string>(maxLength: 15,nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                },
                constraints: table => { table.PrimaryKey("PK_Enterprises", x => x.Id); });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Enterprises");
        }
    }
}
