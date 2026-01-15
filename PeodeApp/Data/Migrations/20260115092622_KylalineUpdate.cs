using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeodeApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class KylalineUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Kylalined_PyhaID",
                table: "Kylalined",
                column: "PyhaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Kylalined_Pyhad_PyhaID",
                table: "Kylalined",
                column: "PyhaID",
                principalTable: "Pyhad",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kylalined_Pyhad_PyhaID",
                table: "Kylalined");

            migrationBuilder.DropIndex(
                name: "IX_Kylalined_PyhaID",
                table: "Kylalined");
        }
    }
}
