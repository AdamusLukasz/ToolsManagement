using Microsoft.EntityFrameworkCore.Migrations;

namespace ToolsManagement.Migrations
{
    public partial class migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Diameter = table.Column<double>(type: "float", nullable: false),
                    Vc = table.Column<int>(type: "int", nullable: false),
                    Fz = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EndMillCutters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Diameter = table.Column<double>(type: "float", nullable: false),
                    Vc = table.Column<int>(type: "int", nullable: false),
                    Fz = table.Column<double>(type: "float", nullable: false),
                    NumberOfTeeth = table.Column<int>(type: "int", nullable: false),
                    WorkingLength = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EndMillCutters", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drills");

            migrationBuilder.DropTable(
                name: "EndMillCutters");
        }
    }
}
