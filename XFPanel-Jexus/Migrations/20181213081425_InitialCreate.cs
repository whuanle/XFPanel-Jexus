using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace XFPanelJexus.Web.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "jexusSqls",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NameID = table.Column<int>(nullable: false),
                    DownM = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false),
                    SHType = table.Column<string>(nullable: true),
                    FilePath = table.Column<string>(nullable: true),
                    Sitename = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jexusSqls", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "jexusSqls");
        }
    }
}
