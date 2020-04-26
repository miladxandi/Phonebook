using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvancePhonebook.Data.Migrations
{
    public partial class Descriptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Descriptions",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Topic = table.Column<string>(maxLength: 256, nullable: true),
                    Description = table.Column<string>( nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                },
                constraints: table => { table.PrimaryKey("PK_Descriptions", x => x.Id); });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Descriptions");
        }
    }
}
