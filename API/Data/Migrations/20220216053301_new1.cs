using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    public partial class new1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_studentClass_StudentClassId",
                table: "Attendances");

            migrationBuilder.DropIndex(
                name: "IX_Attendances_StudentClassId",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "StudentClassId",
                table: "Attendances");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentClassId",
                table: "Attendances",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_StudentClassId",
                table: "Attendances",
                column: "StudentClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_studentClass_StudentClassId",
                table: "Attendances",
                column: "StudentClassId",
                principalTable: "studentClass",
                principalColumn: "Id");
        }
    }
}
