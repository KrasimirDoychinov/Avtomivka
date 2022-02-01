using Microsoft.EntityFrameworkCore.Migrations;

namespace Avtomivka.A.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Program_Worker_WorkerId",
                schema: "17118057",
                table: "Program");

            migrationBuilder.DropIndex(
                name: "IX_Program_WorkerId",
                schema: "17118057",
                table: "Program");

            migrationBuilder.DropColumn(
                name: "WorkerId",
                schema: "17118057",
                table: "Program");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                schema: "17118057",
                table: "WashReservation",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WashReservation_UserId",
                schema: "17118057",
                table: "WashReservation",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WashReservation_AspNetUsers_UserId",
                schema: "17118057",
                table: "WashReservation",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WashReservation_AspNetUsers_UserId",
                schema: "17118057",
                table: "WashReservation");

            migrationBuilder.DropIndex(
                name: "IX_WashReservation_UserId",
                schema: "17118057",
                table: "WashReservation");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "17118057",
                table: "WashReservation");

            migrationBuilder.AddColumn<string>(
                name: "WorkerId",
                schema: "17118057",
                table: "Program",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Program_WorkerId",
                schema: "17118057",
                table: "Program",
                column: "WorkerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Program_Worker_WorkerId",
                schema: "17118057",
                table: "Program",
                column: "WorkerId",
                principalSchema: "17118057",
                principalTable: "Worker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
