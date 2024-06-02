using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca.Migrations
{
    /// <inheritdoc />
    public partial class segundaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    Identificador = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    PaisOrigen = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    IdiomaNativo = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Estado = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Autores__F2374EB187A61A20", x => x.Identificador);
                });

            migrationBuilder.CreateTable(
                name: "Ciencias",
                columns: table => new
                {
                    Identificador = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    Estado = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ciencias__F2374EB127E7D75D", x => x.Identificador);
                });

            migrationBuilder.CreateTable(
                name: "Editoras",
                columns: table => new
                {
                    Identificador = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    Estado = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Editoras__F2374EB170C37B1E", x => x.Identificador);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Identificador = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Cedula = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    TandaLabor = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    PorcientoComision = table.Column<decimal>(type: "decimal(5, 2)", nullable: true),
                    FechaIngreso = table.Column<DateOnly>(type: "TEXT", nullable: true, defaultValueSql: "GETDATE()"),
                    Estado = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Empleado__F2374EB1C058497D", x => x.Identificador);
                });

            migrationBuilder.CreateTable(
                name: "Idiomas",
                columns: table => new
                {
                    Identificador = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    Estado = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Idiomas__F2374EB1BFCBD7E5", x => x.Identificador);
                });

            migrationBuilder.CreateTable(
                name: "TiposBibliografia",
                columns: table => new
                {
                    Identificador = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    Estado = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TiposBib__F2374EB192DD4C49", x => x.Identificador);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Identificador = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Cedula = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    NoCarnet = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    TipoPersona = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Estado = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuarios__F2374EB14AAEC3E4", x => x.Identificador);
                });

            migrationBuilder.CreateTable(
                name: "Libros",
                columns: table => new
                {
                    Identificador = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    SignaturaTopografica = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    ISBN = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    TipoBibliografia = table.Column<int>(type: "INTEGER", nullable: true),
                    Autores = table.Column<int>(type: "INTEGER", nullable: true),
                    Editora = table.Column<int>(type: "INTEGER", nullable: true),
                    AnioPublicacion = table.Column<int>(type: "INTEGER", nullable: true),
                    Ciencia = table.Column<int>(type: "INTEGER", nullable: true),
                    Idioma = table.Column<int>(type: "INTEGER", nullable: true),
                    Estado = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Libros__F2374EB1201BE782", x => x.Identificador);
                    table.ForeignKey(
                        name: "FK__Libros__Autores__6754599E",
                        column: x => x.Autores,
                        principalTable: "Autores",
                        principalColumn: "Identificador");
                    table.ForeignKey(
                        name: "FK__Libros__Ciencia__693CA210",
                        column: x => x.Ciencia,
                        principalTable: "Ciencias",
                        principalColumn: "Identificador");
                    table.ForeignKey(
                        name: "FK__Libros__Editora__68487DD7",
                        column: x => x.Editora,
                        principalTable: "Editoras",
                        principalColumn: "Identificador");
                    table.ForeignKey(
                        name: "FK__Libros__Idioma__6A30C649",
                        column: x => x.Idioma,
                        principalTable: "Idiomas",
                        principalColumn: "Identificador");
                    table.ForeignKey(
                        name: "FK__Libros__TipoBibl__66603565",
                        column: x => x.TipoBibliografia,
                        principalTable: "TiposBibliografia",
                        principalColumn: "Identificador");
                });

            migrationBuilder.CreateTable(
                name: "PrestamoDevolucion",
                columns: table => new
                {
                    NoPrestamo = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Empleado = table.Column<int>(type: "INTEGER", nullable: true),
                    Libro = table.Column<int>(type: "INTEGER", nullable: true),
                    Usuario = table.Column<int>(type: "INTEGER", nullable: true),
                    FechaPrestamo = table.Column<DateOnly>(type: "TEXT", nullable: true),
                    FechaDevolucion = table.Column<DateOnly>(type: "TEXT", nullable: true),
                    MontoXDia = table.Column<decimal>(type: "decimal(10, 2)", nullable: true),
                    CantidadDias = table.Column<int>(type: "INTEGER", nullable: true),
                    Comentario = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    Estado = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Prestamo__E21CCFF3472922B1", x => x.NoPrestamo);
                    table.ForeignKey(
                        name: "FK__PrestamoD__Emple__70DDC3D8",
                        column: x => x.Empleado,
                        principalTable: "Empleados",
                        principalColumn: "Identificador");
                    table.ForeignKey(
                        name: "FK__PrestamoD__Libro__71D1E811",
                        column: x => x.Libro,
                        principalTable: "Libros",
                        principalColumn: "Identificador");
                    table.ForeignKey(
                        name: "FK__PrestamoD__Usuar__72C60C4A",
                        column: x => x.Usuario,
                        principalTable: "Usuarios",
                        principalColumn: "Identificador");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Libros_Autores",
                table: "Libros",
                column: "Autores");

            migrationBuilder.CreateIndex(
                name: "IX_Libros_Ciencia",
                table: "Libros",
                column: "Ciencia");

            migrationBuilder.CreateIndex(
                name: "IX_Libros_Editora",
                table: "Libros",
                column: "Editora");

            migrationBuilder.CreateIndex(
                name: "IX_Libros_Idioma",
                table: "Libros",
                column: "Idioma");

            migrationBuilder.CreateIndex(
                name: "IX_Libros_TipoBibliografia",
                table: "Libros",
                column: "TipoBibliografia");

            migrationBuilder.CreateIndex(
                name: "IX_PrestamoDevolucion_Empleado",
                table: "PrestamoDevolucion",
                column: "Empleado");

            migrationBuilder.CreateIndex(
                name: "IX_PrestamoDevolucion_Libro",
                table: "PrestamoDevolucion",
                column: "Libro");

            migrationBuilder.CreateIndex(
                name: "IX_PrestamoDevolucion_Usuario",
                table: "PrestamoDevolucion",
                column: "Usuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrestamoDevolucion");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Libros");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Autores");

            migrationBuilder.DropTable(
                name: "Ciencias");

            migrationBuilder.DropTable(
                name: "Editoras");

            migrationBuilder.DropTable(
                name: "Idiomas");

            migrationBuilder.DropTable(
                name: "TiposBibliografia");
        }
    }
}
