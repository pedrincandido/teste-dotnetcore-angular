using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Teste.Impl.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_Gender",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Gender", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USER",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(maxLength: 20, nullable: false),
                    PASSWORD = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tb_Person",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NOME = table.Column<string>(maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    CPF = table.Column<string>(maxLength: 11, nullable: false),
                    GenderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Person", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tb_Person_tb_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "tb_Gender",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CREDIARIO",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FINAL_VALUE = table.Column<double>(nullable: false),
                    SCHEDULING_PAYMENT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RATES = table.Column<int>(nullable: true),
                    PersonId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CREDIARIO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CREDIARIO_tb_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "tb_Person",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CREDIARIO_USER_UserId",
                        column: x => x.UserId,
                        principalTable: "USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SALE",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PURCHASE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<double>(nullable: false),
                    ENABLE_SALE = table.Column<bool>(nullable: false),
                    CREDIARIO_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SALE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SALE_CREDIARIO_CREDIARIO_ID",
                        column: x => x.CREDIARIO_ID,
                        principalTable: "CREDIARIO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CREDIARIO_PersonId",
                table: "CREDIARIO",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_CREDIARIO_UserId",
                table: "CREDIARIO",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SALE_CREDIARIO_ID",
                table: "SALE",
                column: "CREDIARIO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Person_GenderId",
                table: "tb_Person",
                column: "GenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SALE");

            migrationBuilder.DropTable(
                name: "CREDIARIO");

            migrationBuilder.DropTable(
                name: "tb_Person");

            migrationBuilder.DropTable(
                name: "USER");

            migrationBuilder.DropTable(
                name: "tb_Gender");
        }
    }
}
