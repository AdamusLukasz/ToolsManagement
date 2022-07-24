using Microsoft.EntityFrameworkCore.Migrations;

namespace ToolsManagement.Migrations
{
    public partial class migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EndMillCutterId",
                table: "EndMillCutterParameters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EndMillCutterParameters_EndMillCutterId",
                table: "EndMillCutterParameters",
                column: "EndMillCutterId");

            migrationBuilder.AddForeignKey(
                name: "FK_EndMillCutterParameters_EndMillCutters_EndMillCutterId",
                table: "EndMillCutterParameters",
                column: "EndMillCutterId",
                principalTable: "EndMillCutters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EndMillCutterParameters_EndMillCutters_EndMillCutterId",
                table: "EndMillCutterParameters");

            migrationBuilder.DropIndex(
                name: "IX_EndMillCutterParameters_EndMillCutterId",
                table: "EndMillCutterParameters");

            migrationBuilder.DropColumn(
                name: "EndMillCutterId",
                table: "EndMillCutterParameters");
        }
    }
}
