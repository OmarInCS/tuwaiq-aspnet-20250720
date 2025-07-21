using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Migrations
{
    /// <inheritdoc />
    public partial class Refactors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Salary",
                table: "Doctors",
                type: "float",
                nullable: false,
                defaultValue: 10000.0,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "SpecId",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_SpecId",
                table: "Doctors",
                column: "SpecId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Specialities_SpecId",
                table: "Doctors",
                column: "SpecId",
                principalTable: "Specialities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Specialities_SpecId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_SpecId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "SpecId",
                table: "Doctors");

            migrationBuilder.AlterColumn<double>(
                name: "Salary",
                table: "Doctors",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 10000.0);
        }
    }
}
