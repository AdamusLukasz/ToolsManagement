using Microsoft.EntityFrameworkCore.Migrations;

namespace ToolsManagement.Migrations
{
    public partial class AddLengthToDrillEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreateDrillParametersDto");

            migrationBuilder.DropTable(
                name: "CreateDrillDto");

            migrationBuilder.AddColumn<int>(
                name: "Length",
                table: "Drills",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Length",
                table: "Drills");

            migrationBuilder.CreateTable(
                name: "CreateDrillDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Diameter = table.Column<double>(type: "float", maxLength: 40, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreateDrillDto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreateDrillParametersDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDrillDtoId = table.Column<int>(type: "int", nullable: true),
                    DrillId = table.Column<int>(type: "int", nullable: false),
                    Fz = table.Column<double>(type: "float", nullable: false),
                    Vc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreateDrillParametersDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreateDrillParametersDto_CreateDrillDto_CreateDrillDtoId",
                        column: x => x.CreateDrillDtoId,
                        principalTable: "CreateDrillDto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CreateDrillParametersDto_CreateDrillDtoId",
                table: "CreateDrillParametersDto",
                column: "CreateDrillDtoId");
        }
    }
}
