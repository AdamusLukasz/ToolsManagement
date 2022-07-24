using Microsoft.EntityFrameworkCore.Migrations;

namespace ToolsManagement.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fz",
                table: "EndMillCutters");

            migrationBuilder.DropColumn(
                name: "NumberOfTeeth",
                table: "EndMillCutters");

            migrationBuilder.DropColumn(
                name: "Vc",
                table: "EndMillCutters");

            migrationBuilder.DropColumn(
                name: "WorkingLength",
                table: "EndMillCutters");

            migrationBuilder.DropColumn(
                name: "Fz",
                table: "Drills");

            migrationBuilder.DropColumn(
                name: "Vc",
                table: "Drills");

            migrationBuilder.CreateTable(
                name: "CreateDrillDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Diameter = table.Column<double>(type: "float", maxLength: 40, nullable: false),
                    Vc = table.Column<int>(type: "int", maxLength: 40, nullable: false),
                    Fz = table.Column<double>(type: "float", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreateDrillDto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrillParameters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vc = table.Column<int>(type: "int", nullable: false),
                    Fz = table.Column<double>(type: "float", nullable: false),
                    DrillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrillParameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrillParameters_Drills_DrillId",
                        column: x => x.DrillId,
                        principalTable: "Drills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EndMillCutterParameters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vc = table.Column<int>(type: "int", nullable: false),
                    Fz = table.Column<double>(type: "float", nullable: false),
                    NumberOfTeeth = table.Column<int>(type: "int", nullable: false),
                    WorkingLength = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EndMillCutterParameters", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DrillParameters_DrillId",
                table: "DrillParameters",
                column: "DrillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreateDrillDto");

            migrationBuilder.DropTable(
                name: "DrillParameters");

            migrationBuilder.DropTable(
                name: "EndMillCutterParameters");

            migrationBuilder.AddColumn<double>(
                name: "Fz",
                table: "EndMillCutters",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfTeeth",
                table: "EndMillCutters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Vc",
                table: "EndMillCutters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WorkingLength",
                table: "EndMillCutters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Fz",
                table: "Drills",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Vc",
                table: "Drills",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
