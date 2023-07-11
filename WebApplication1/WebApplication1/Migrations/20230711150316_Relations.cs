using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class Relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {



            migrationBuilder.DropTable(
                name: "CompanyModel");

            migrationBuilder.DropTable(
                name: "PersonModel");

            migrationBuilder.DropTable(
                name: "EventModel");


            migrationBuilder.CreateTable(
                name: "CompanyModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NrOfAtendees = table.Column<int>(type: "int", nullable: false),
                    PayingMethod = table.Column<bool>(type: "bit", nullable: false),
                    AdditionalInfo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyModel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EventModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalInfo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventModel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PersonModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonalId = table.Column<int>(type: "int", nullable: false),
                    PayingMethod = table.Column<bool>(type: "bit", nullable: false),
                    AdditionalInfo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonModel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EventCompanyModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyModelID = table.Column<int>(type: "int", nullable: true),
                    EventModelID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventCompanyModel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EventCompanyModel_CompanyModel_CompanyModelID",
                        column: x => x.CompanyModelID,
                        principalTable: "CompanyModel",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_EventCompanyModel_EventModel_EventModelID",
                        column: x => x.EventModelID,
                        principalTable: "EventModel",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "EventPersonModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventModelID = table.Column<int>(type: "int", nullable: true),
                    PersonModelID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventPersonModel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EventPersonModel_EventModel_EventModelID",
                        column: x => x.EventModelID,
                        principalTable: "EventModel",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_EventPersonModel_PersonModel_PersonModelID",
                        column: x => x.PersonModelID,
                        principalTable: "PersonModel",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventCompanyModel_CompanyModelID",
                table: "EventCompanyModel",
                column: "CompanyModelID");

            migrationBuilder.CreateIndex(
                name: "IX_EventCompanyModel_EventModelID",
                table: "EventCompanyModel",
                column: "EventModelID");

            migrationBuilder.CreateIndex(
                name: "IX_EventPersonModel_EventModelID",
                table: "EventPersonModel",
                column: "EventModelID");

            migrationBuilder.CreateIndex(
                name: "IX_EventPersonModel_PersonModelID",
                table: "EventPersonModel",
                column: "PersonModelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventCompanyModel");

            migrationBuilder.DropTable(
                name: "EventPersonModel");

            migrationBuilder.DropTable(
                name: "CompanyModel");

            migrationBuilder.DropTable(
                name: "EventModel");

            migrationBuilder.DropTable(
                name: "PersonModel");
        }
    }
}
