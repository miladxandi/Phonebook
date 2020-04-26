using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace AdvancePhonebook.Data.Migrations
{
    public partial class Info : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    EnterpriseId = table.Column<long>(maxLength: 150, nullable: true),
                    Role = table.Column<string>(maxLength: 150, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 13, nullable: true),
                    Line = table.Column<int>(maxLength: 5, nullable: true),
                    CellPhone = table.Column<string>(maxLength: 13, nullable: true),
                    Fax = table.Column<string>(maxLength: 13, nullable: true),
                    Address = table.Column<string>(maxLength: 13, nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Group = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                },
                constraints: table => {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            /* Relational Tables */

            migrationBuilder.CreateTable(
                name: "UserContacts",
                columns: table => new
                {
                    InfoId = table.Column<long>(nullable: true),
                    UserId = table.Column<long>(nullable: true),
                });
            migrationBuilder.CreateTable(
                name: "DescriptionContacts",
                columns: table => new
                {
                    InfoId = table.Column<long>(nullable: true),
                    DescriptionId = table.Column<long>(nullable: true),
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Contacts");
            migrationBuilder.DropTable(name: "UserContacts");
            migrationBuilder.DropTable(name: "DescriptionContacts");
        }
    }
}
