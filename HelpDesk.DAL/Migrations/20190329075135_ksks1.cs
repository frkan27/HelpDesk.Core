using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HelpDesk.DAL.Migrations
{
    public partial class ksks1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BillPath",
                table: "FaultRecords",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                table: "FaultRecords",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "FaultRecords",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FaultCreatedDate",
                table: "FaultRecords",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FaultLastCheckDate",
                table: "FaultRecords",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FaultRecordState",
                table: "FaultRecords",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FaultSolveDate",
                table: "FaultRecords",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FitechBehaviorScorei",
                table: "FaultRecords",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "OperatorAccept",
                table: "FaultRecords",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "OperatorAcceptDate",
                table: "FaultRecords",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OperatorId",
                table: "FaultRecords",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OpinionsAboutFitech",
                table: "FaultRecords",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServiceScore",
                table: "FaultRecords",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SurveyCode",
                table: "FaultRecords",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SurveyIsCompleted",
                table: "FaultRecords",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "TechnicianAppointedDate",
                table: "FaultRecords",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TechnicianBehaviorScore",
                table: "FaultRecords",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TechnicianId",
                table: "FaultRecords",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TechnicianInfoPoints",
                table: "FaultRecords",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TechnicianState",
                table: "FaultRecords",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "latitude",
                table: "FaultRecords",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "longitude",
                table: "FaultRecords",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ActivationCode",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AvatarPath",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Longtitude",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FaultLOG",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUserId = table.Column<string>(maxLength: 450, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    AuthorizeRole = table.Column<int>(nullable: false),
                    FaultId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaultLOG", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FaultLOG_FaultRecords_FaultId",
                        column: x => x.FaultId,
                        principalTable: "FaultRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUserId = table.Column<string>(maxLength: 450, nullable: true),
                    Path = table.Column<string>(nullable: false),
                    FaultId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_FaultRecords_FaultId",
                        column: x => x.FaultId,
                        principalTable: "FaultRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FaultRecords_CustomerId",
                table: "FaultRecords",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_FaultRecords_OperatorId",
                table: "FaultRecords",
                column: "OperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_FaultRecords_TechnicianId",
                table: "FaultRecords",
                column: "TechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_FaultLOG_FaultId",
                table: "FaultLOG",
                column: "FaultId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_FaultId",
                table: "Photos",
                column: "FaultId");

            migrationBuilder.AddForeignKey(
                name: "FK_FaultRecords_AspNetUsers_CustomerId",
                table: "FaultRecords",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FaultRecords_AspNetUsers_OperatorId",
                table: "FaultRecords",
                column: "OperatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FaultRecords_AspNetUsers_TechnicianId",
                table: "FaultRecords",
                column: "TechnicianId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FaultRecords_AspNetUsers_CustomerId",
                table: "FaultRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_FaultRecords_AspNetUsers_OperatorId",
                table: "FaultRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_FaultRecords_AspNetUsers_TechnicianId",
                table: "FaultRecords");

            migrationBuilder.DropTable(
                name: "FaultLOG");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_FaultRecords_CustomerId",
                table: "FaultRecords");

            migrationBuilder.DropIndex(
                name: "IX_FaultRecords_OperatorId",
                table: "FaultRecords");

            migrationBuilder.DropIndex(
                name: "IX_FaultRecords_TechnicianId",
                table: "FaultRecords");

            migrationBuilder.DropColumn(
                name: "BillPath",
                table: "FaultRecords");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "FaultRecords");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "FaultRecords");

            migrationBuilder.DropColumn(
                name: "FaultCreatedDate",
                table: "FaultRecords");

            migrationBuilder.DropColumn(
                name: "FaultLastCheckDate",
                table: "FaultRecords");

            migrationBuilder.DropColumn(
                name: "FaultRecordState",
                table: "FaultRecords");

            migrationBuilder.DropColumn(
                name: "FaultSolveDate",
                table: "FaultRecords");

            migrationBuilder.DropColumn(
                name: "FitechBehaviorScorei",
                table: "FaultRecords");

            migrationBuilder.DropColumn(
                name: "OperatorAccept",
                table: "FaultRecords");

            migrationBuilder.DropColumn(
                name: "OperatorAcceptDate",
                table: "FaultRecords");

            migrationBuilder.DropColumn(
                name: "OperatorId",
                table: "FaultRecords");

            migrationBuilder.DropColumn(
                name: "OpinionsAboutFitech",
                table: "FaultRecords");

            migrationBuilder.DropColumn(
                name: "ServiceScore",
                table: "FaultRecords");

            migrationBuilder.DropColumn(
                name: "SurveyCode",
                table: "FaultRecords");

            migrationBuilder.DropColumn(
                name: "SurveyIsCompleted",
                table: "FaultRecords");

            migrationBuilder.DropColumn(
                name: "TechnicianAppointedDate",
                table: "FaultRecords");

            migrationBuilder.DropColumn(
                name: "TechnicianBehaviorScore",
                table: "FaultRecords");

            migrationBuilder.DropColumn(
                name: "TechnicianId",
                table: "FaultRecords");

            migrationBuilder.DropColumn(
                name: "TechnicianInfoPoints",
                table: "FaultRecords");

            migrationBuilder.DropColumn(
                name: "TechnicianState",
                table: "FaultRecords");

            migrationBuilder.DropColumn(
                name: "latitude",
                table: "FaultRecords");

            migrationBuilder.DropColumn(
                name: "longitude",
                table: "FaultRecords");

            migrationBuilder.DropColumn(
                name: "ActivationCode",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AvatarPath",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Longtitude",
                table: "AspNetUsers");
        }
    }
}
