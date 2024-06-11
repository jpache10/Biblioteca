using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca.Migrations
{
    /// <inheritdoc />
    public partial class newTableUsuarioEmpleado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Libros__Autores__6754599E",
                table: "Libros");

            migrationBuilder.DropForeignKey(
                name: "FK__Libros__Ciencia__693CA210",
                table: "Libros");

            migrationBuilder.DropForeignKey(
                name: "FK__Libros__Editora__68487DD7",
                table: "Libros");

            migrationBuilder.DropForeignKey(
                name: "FK__Libros__Idioma__6A30C649",
                table: "Libros");

            migrationBuilder.DropForeignKey(
                name: "FK__Libros__TipoBibl__66603565",
                table: "Libros");

            migrationBuilder.AlterColumn<string>(
                name: "TipoPersona",
                table: "Usuarios",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cedula",
                table: "Usuarios",
                type: "TEXT",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "TiposBibliografia",
                type: "TEXT",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TipoBibliografia",
                table: "Libros",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Idioma",
                table: "Libros",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                table: "Libros",
                type: "TEXT",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Editora",
                table: "Libros",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Libros",
                type: "TEXT",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Ciencia",
                table: "Libros",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Autores",
                table: "Libros",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Idiomas",
                type: "TEXT",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TandaLabor",
                table: "Empleados",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PorcientoComision",
                table: "Empleados",
                type: "decimal(5, 2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(5, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Empleados",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cedula",
                table: "Empleados",
                type: "TEXT",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Editoras",
                type: "TEXT",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Ciencias",
                type: "TEXT",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PaisOrigen",
                table: "Autores",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Autores",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdiomaNativo",
                table: "Autores",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "UsuariosEmpleado",
                columns: table => new
                {
                    Identificador = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Rol = table.Column<string>(type: "TEXT", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "GETDATE()"),
                    FechaUltimoInicioSesion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RestablecerPassword = table.Column<bool>(type: "INTEGER", nullable: false),
                    Estado = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true),
                    Empleado = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Empleado__F2374EB1C058497D", x => x.Identificador);
                    table.ForeignKey(
                        name: "FK_UsuariosEmpleado_Empleados_Empleado",
                        column: x => x.Empleado,
                        principalTable: "Empleados",
                        principalColumn: "Identificador",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosEmpleado_Empleado",
                table: "UsuariosEmpleado",
                column: "Empleado");

            migrationBuilder.AddForeignKey(
                name: "FK__Libros__Autores__6754599E",
                table: "Libros",
                column: "Autores",
                principalTable: "Autores",
                principalColumn: "Identificador",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Libros__Ciencia__693CA210",
                table: "Libros",
                column: "Ciencia",
                principalTable: "Ciencias",
                principalColumn: "Identificador",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Libros__Editora__68487DD7",
                table: "Libros",
                column: "Editora",
                principalTable: "Editoras",
                principalColumn: "Identificador",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Libros__Idioma__6A30C649",
                table: "Libros",
                column: "Idioma",
                principalTable: "Idiomas",
                principalColumn: "Identificador",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Libros__TipoBibl__66603565",
                table: "Libros",
                column: "TipoBibliografia",
                principalTable: "TiposBibliografia",
                principalColumn: "Identificador",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Libros__Autores__6754599E",
                table: "Libros");

            migrationBuilder.DropForeignKey(
                name: "FK__Libros__Ciencia__693CA210",
                table: "Libros");

            migrationBuilder.DropForeignKey(
                name: "FK__Libros__Editora__68487DD7",
                table: "Libros");

            migrationBuilder.DropForeignKey(
                name: "FK__Libros__Idioma__6A30C649",
                table: "Libros");

            migrationBuilder.DropForeignKey(
                name: "FK__Libros__TipoBibl__66603565",
                table: "Libros");

            migrationBuilder.DropTable(
                name: "UsuariosEmpleado");

            migrationBuilder.AlterColumn<string>(
                name: "TipoPersona",
                table: "Usuarios",
                type: "TEXT",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Cedula",
                table: "Usuarios",
                type: "TEXT",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "TiposBibliografia",
                type: "TEXT",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<int>(
                name: "TipoBibliografia",
                table: "Libros",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "Idioma",
                table: "Libros",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                table: "Libros",
                type: "TEXT",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<int>(
                name: "Editora",
                table: "Libros",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Libros",
                type: "TEXT",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<int>(
                name: "Ciencia",
                table: "Libros",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "Autores",
                table: "Libros",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Idiomas",
                type: "TEXT",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "TandaLabor",
                table: "Empleados",
                type: "TEXT",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<decimal>(
                name: "PorcientoComision",
                table: "Empleados",
                type: "decimal(5, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(5, 2)");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Empleados",
                type: "TEXT",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Cedula",
                table: "Empleados",
                type: "TEXT",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Editoras",
                type: "TEXT",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Ciencias",
                type: "TEXT",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "PaisOrigen",
                table: "Autores",
                type: "TEXT",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Autores",
                type: "TEXT",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "IdiomaNativo",
                table: "Autores",
                type: "TEXT",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100);

            migrationBuilder.AddForeignKey(
                name: "FK__Libros__Autores__6754599E",
                table: "Libros",
                column: "Autores",
                principalTable: "Autores",
                principalColumn: "Identificador");

            migrationBuilder.AddForeignKey(
                name: "FK__Libros__Ciencia__693CA210",
                table: "Libros",
                column: "Ciencia",
                principalTable: "Ciencias",
                principalColumn: "Identificador");

            migrationBuilder.AddForeignKey(
                name: "FK__Libros__Editora__68487DD7",
                table: "Libros",
                column: "Editora",
                principalTable: "Editoras",
                principalColumn: "Identificador");

            migrationBuilder.AddForeignKey(
                name: "FK__Libros__Idioma__6A30C649",
                table: "Libros",
                column: "Idioma",
                principalTable: "Idiomas",
                principalColumn: "Identificador");

            migrationBuilder.AddForeignKey(
                name: "FK__Libros__TipoBibl__66603565",
                table: "Libros",
                column: "TipoBibliografia",
                principalTable: "TiposBibliografia",
                principalColumn: "Identificador");
        }
    }
}
