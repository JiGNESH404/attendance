using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    public partial class DBFinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "studentClassId",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "studentClassId",
                table: "Attendances",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "studentClass",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    className = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentClass", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_studentClassId",
                table: "Users",
                column: "studentClassId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Users_studentClass_studentClassId",
                table: "Users",
                column: "studentClassId",
                principalTable: "studentClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_studentClass_studentClassId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_studentClass_studentClassId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "studentClass");

            migrationBuilder.DropIndex(
                name: "IX_Users_studentClassId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Attendances_studentClassId",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "studentClassId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "studentClassId",
                table: "Attendances");
        }
    }
}
