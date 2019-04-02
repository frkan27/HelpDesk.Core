using Microsoft.EntityFrameworkCore.Migrations;

namespace HelpDesk.DAL.Migrations
{
    public partial class x32 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FaultRecords_AspNetUsers_CustomerId",
                table: "FaultRecords");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "FaultRecords",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_FaultRecords_AspNetUsers_CustomerId",
                table: "FaultRecords",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FaultRecords_AspNetUsers_CustomerId",
                table: "FaultRecords");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "FaultRecords",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FaultRecords_AspNetUsers_CustomerId",
                table: "FaultRecords",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
