using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionCoursWeb.Migrations
{
    public partial class Initialisation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diplomes",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Niveau = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diplomes", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Eleves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CodePostal = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Ville = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eleves", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Debut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiplomeCode = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Promotions_Diplomes_DiplomeCode",
                        column: x => x.DiplomeCode,
                        principalTable: "Diplomes",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ElevePromotion",
                columns: table => new
                {
                    ElevesId = table.Column<int>(type: "int", nullable: false),
                    PromotionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElevePromotion", x => new { x.ElevesId, x.PromotionsId });
                    table.ForeignKey(
                        name: "FK_ElevePromotion_Eleves_ElevesId",
                        column: x => x.ElevesId,
                        principalTable: "Eleves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElevePromotion_Promotions_PromotionsId",
                        column: x => x.PromotionsId,
                        principalTable: "Promotions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ElevePromotion_PromotionsId",
                table: "ElevePromotion",
                column: "PromotionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_DiplomeCode",
                table: "Promotions",
                column: "DiplomeCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElevePromotion");

            migrationBuilder.DropTable(
                name: "Eleves");

            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DropTable(
                name: "Diplomes");
        }
    }
}
