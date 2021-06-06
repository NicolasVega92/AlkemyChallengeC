using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlkemyAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pelicula",
                columns: table => new
                {
                    ID_PELICULA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TITULO = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    FECHA_CREACION = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CALIFICACION = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pelicula", x => x.ID_PELICULA);
                });

            migrationBuilder.CreateTable(
                name: "Personaje",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOMBRE = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    EDAD = table.Column<int>(type: "int", nullable: false),
                    PESO = table.Column<int>(type: "int", nullable: true),
                    HISTORIA = table.Column<string>(type: "text", nullable: false),
                    IMAGEN = table.Column<byte[]>(type: "image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personaje", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    ID_GENERO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOMBRE = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IMAGEN = table.Column<byte[]>(type: "image", nullable: true),
                    ID_PELICULA = table.Column<int>(type: "int", nullable: true),
                    PeliculaID_PELICULA = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.ID_GENERO);
                    table.ForeignKey(
                        name: "FK_Genero_Pelicula_PeliculaID_PELICULA",
                        column: x => x.PeliculaID_PELICULA,
                        principalTable: "Pelicula",
                        principalColumn: "ID_PELICULA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PeliculaPersonaje",
                columns: table => new
                {
                    PeliculasID_PELICULA = table.Column<int>(type: "int", nullable: false),
                    PersonajesID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeliculaPersonaje", x => new { x.PeliculasID_PELICULA, x.PersonajesID });
                    table.ForeignKey(
                        name: "FK_PeliculaPersonaje_Pelicula_PeliculasID_PELICULA",
                        column: x => x.PeliculasID_PELICULA,
                        principalTable: "Pelicula",
                        principalColumn: "ID_PELICULA",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeliculaPersonaje_Personaje_PersonajesID",
                        column: x => x.PersonajesID,
                        principalTable: "Personaje",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Genero_PeliculaID_PELICULA",
                table: "Genero",
                column: "PeliculaID_PELICULA");

            migrationBuilder.CreateIndex(
                name: "IX_PeliculaPersonaje_PersonajesID",
                table: "PeliculaPersonaje",
                column: "PersonajesID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Genero");

            migrationBuilder.DropTable(
                name: "PeliculaPersonaje");

            migrationBuilder.DropTable(
                name: "Pelicula");

            migrationBuilder.DropTable(
                name: "Personaje");
        }
    }
}
