using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    public partial class DBFinal1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_studentClass_studentClassId",
                table: "Attendances");

            migrationBuilder.DropIndex(
                name: "IX_Attendances_studentClassId",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "studentClassId",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "studentId",
                table: "Attendances");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "studentClassId",
                table: "Attendances",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "studentId",
                table: "Attendances",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_studentClassId",
                table: "Attendances",
                column: "studentClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_studentClass_studentClassId",
                table: "Attendances",
                column: "studentClassId",
                principalTable: "studentClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
