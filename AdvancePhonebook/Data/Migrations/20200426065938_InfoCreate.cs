using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvancePhonebook.Data.Migrations
{
    public partial class InfoCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Info",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    EnterpriseId = table.Column<string>(maxLength: 150, nullable: true),
                    Role = table.Column<string>(maxLength: 150, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 13,nullable: true),
                    Line = table.Column<int>(maxLength: 5,nullable: true),
                    CellPhone = table.Column<string>(maxLength: 13,nullable: true),
                    Fax = table.Column<string>(maxLength: 13,nullable: true),
                    Address = table.Column<string>(maxLength: 13,nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Group = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                },
                constraints: table => { table.PrimaryKey("PK_Info", x => x.Id); });
            
            /* Relational Tables */
            
            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: true),
                    InfoId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                },
                constraints: table => { table.PrimaryKey("PK_UserInfo", x => x.Id); });
            
            migrationBuilder.CreateTable(
                name: "DescriptionInfo",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: true),
                    InfoId = table.Column<string>(nullable: true),
                    DescriptionId = table.Column<string>(nullable: true),
                },
                constraints: table => { table.PrimaryKey("PK_DescriptionInfo", x => x.Id); });
            
            migrationBuilder.CreateTable(
                name: "EnterpriseInfo",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: true),
                    InfoId = table.Column<string>(nullable: true),
                    EnterpriseId = table.Column<string>(nullable: true),
                },
                constraints: table => { table.PrimaryKey("PK_EnterpriseInfo", x => x.Id); });
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Info");
            migrationBuilder.DropTable(name: "UserInfo");
            migrationBuilder.DropTable(name: "DescriptionInfo");
            migrationBuilder.DropTable(name: "EnterpriseInfo");
        }
    }
}
