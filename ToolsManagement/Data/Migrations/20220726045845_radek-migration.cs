using Microsoft.EntityFrameworkCore.Migrations;

namespace ToolsManagement.Migrations
{
    public partial class radekmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fz",
                table: "CreateDrillDto");

            migrationBuilder.DropColumn(
                name: "Vc",
                table: "CreateDrillDto");

            migrationBuilder.CreateTable(
                name: "CreateDrillParametersDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vc = table.Column<int>(type: "int", nullable: false),
                    Fz = table.Column<double>(type: "float", nullable: false),
                    DrillId = table.Column<int>(type: "int", nullable: false),
                    CreateDrillDtoId = table.Column<int>(type: "int", nullable: true)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreateDrillParametersDto");

            migrationBuilder.AddColumn<double>(
                name: "Fz",
                table: "CreateDrillDto",
                type: "float",
                maxLength: 40,
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Vc",
                table: "CreateDrillDto",
                type: "int",
                maxLength: 40,
                nullable: false,
                defaultValue: 0);
        }
    }
}
