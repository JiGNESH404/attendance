using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    public partial class newmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
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
                name: "IX_Attendances_AppUserId",
                table: "Attendances",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Users_AppUserId",
                table: "Attendances",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Users_AppUserId",
                table: "Attendances");

            migrationBuilder.DropIndex(
                name: "IX_Attendances_AppUserId",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "studentId",
                table: "Attendances");
        }
    }
}
