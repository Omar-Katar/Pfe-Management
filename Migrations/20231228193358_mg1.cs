using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projet_dotnet.Migrations
{
    /// <inheritdoc />
    public partial class mg1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enseignant",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enseignant", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Etudiant",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateNaiss = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etudiant", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Societe",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lib = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Societe", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Pfe",
                columns: table => new
                {
                    PfeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateD = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateF = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EncadrantID = table.Column<int>(type: "int", nullable: false),
                    SocieteID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pfe", x => x.PfeId);
                    table.ForeignKey(
                        name: "FK_Pfe_Enseignant_EncadrantID",
                        column: x => x.EncadrantID,
                        principalTable: "Enseignant",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pfe_Societe_SocieteID",
                        column: x => x.SocieteID,
                        principalTable: "Societe",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pfe_Etudiant",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PfeId = table.Column<int>(type: "int", nullable: false),
                    EtudiantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pfe_Etudiant", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Pfe_Etudiant_Etudiant_EtudiantId",
                        column: x => x.EtudiantId,
                        principalTable: "Etudiant",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pfe_Etudiant_Pfe_PfeId",
                        column: x => x.PfeId,
                        principalTable: "Pfe",
                        principalColumn: "PfeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pfe_EncadrantID",
                table: "Pfe",
                column: "EncadrantID");

            migrationBuilder.CreateIndex(
                name: "IX_Pfe_SocieteID",
                table: "Pfe",
                column: "SocieteID");

            migrationBuilder.CreateIndex(
                name: "IX_Pfe_Etudiant_EtudiantId",
                table: "Pfe_Etudiant",
                column: "EtudiantId");

            migrationBuilder.CreateIndex(
                name: "IX_Pfe_Etudiant_PfeId",
                table: "Pfe_Etudiant",
                column: "PfeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pfe_Etudiant");

            migrationBuilder.DropTable(
                name: "Etudiant");

            migrationBuilder.DropTable(
                name: "Pfe");

            migrationBuilder.DropTable(
                name: "Enseignant");

            migrationBuilder.DropTable(
                name: "Societe");
        }
    }
}
