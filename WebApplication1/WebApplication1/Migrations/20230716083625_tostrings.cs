using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class tostrings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventCompanyModel_EventModel_EventModelID",
                table: "EventCompanyModel");

            migrationBuilder.DropForeignKey(
                name: "FK_EventPersonModel_EventModel_EventModelID",
                table: "EventPersonModel");

            migrationBuilder.DropForeignKey(
                name: "FK_EventPersonModel_PersonModel_PersonModelID",
                table: "EventPersonModel");

            migrationBuilder.AlterColumn<string>(
                name: "PayingMethod",
                table: "PersonModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "PersonModelID",
                table: "EventPersonModel",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EventModelID",
                table: "EventPersonModel",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EventModelID",
                table: "EventCompanyModel",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PayingMethod",
                table: "CompanyModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddForeignKey(
                name: "FK_EventCompanyModel_EventModel_EventModelID",
                table: "EventCompanyModel",
                column: "EventModelID",
                principalTable: "EventModel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventPersonModel_EventModel_EventModelID",
                table: "EventPersonModel",
                column: "EventModelID",
                principalTable: "EventModel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventPersonModel_PersonModel_PersonModelID",
                table: "EventPersonModel",
                column: "PersonModelID",
                principalTable: "PersonModel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventCompanyModel_EventModel_EventModelID",
                table: "EventCompanyModel");

            migrationBuilder.DropForeignKey(
                name: "FK_EventPersonModel_EventModel_EventModelID",
                table: "EventPersonModel");

            migrationBuilder.DropForeignKey(
                name: "FK_EventPersonModel_PersonModel_PersonModelID",
                table: "EventPersonModel");

            migrationBuilder.AlterColumn<bool>(
                name: "PayingMethod",
                table: "PersonModel",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PersonModelID",
                table: "EventPersonModel",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EventModelID",
                table: "EventPersonModel",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EventModelID",
                table: "EventCompanyModel",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "PayingMethod",
                table: "CompanyModel",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EventCompanyModel_EventModel_EventModelID",
                table: "EventCompanyModel",
                column: "EventModelID",
                principalTable: "EventModel",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_EventPersonModel_EventModel_EventModelID",
                table: "EventPersonModel",
                column: "EventModelID",
                principalTable: "EventModel",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_EventPersonModel_PersonModel_PersonModelID",
                table: "EventPersonModel",
                column: "PersonModelID",
                principalTable: "PersonModel",
                principalColumn: "ID");
        }
    }
}
