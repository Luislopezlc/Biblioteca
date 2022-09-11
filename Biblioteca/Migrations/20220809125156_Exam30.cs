using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace Biblioteca.Migrations
{
    public partial class Exam30 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    Fec_regis = table.Column<string>(type: "text", nullable: true),
                    Direccion = table.Column<string>(type: "text", nullable: true),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Genero = table.Column<string>(type: "text", nullable: true),
                    Fec_nac = table.Column<string>(type: "text", nullable: true),
                    Telefono = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Libros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    Categoria = table.Column<string>(type: "text", nullable: true),
                    Editorial = table.Column<string>(type: "text", nullable: true),
                    Fec_publi = table.Column<string>(type: "text", nullable: true),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "text", nullable: true),
                    Idioma = table.Column<string>(type: "text", nullable: true),
                    Isbm = table.Column<string>(type: "text", nullable: true),
                    Autor = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    Apellido = table.Column<string>(type: "text", nullable: true),
                    Fec_reg = table.Column<string>(type: "text", nullable: true),
                    Direccion = table.Column<string>(type: "text", nullable: true),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Genero = table.Column<string>(type: "text", nullable: true),
                    Fec_nac = table.Column<string>(type: "text", nullable: true),
                    Telefono = table.Column<string>(type: "text", nullable: true),
                    Correo = table.Column<string>(type: "text", nullable: true),
                    Contraseña = table.Column<string>(type: "text", nullable: true),
                    FKRol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empleados_Roles_FKRol",
                        column: x => x.FKRol,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Cobro_retardo = table.Column<int>(type: "int", nullable: false),
                    Fec_pres = table.Column<string>(type: "text", nullable: true),
                    Fec_devo = table.Column<string>(type: "text", nullable: true),
                    FKClientes = table.Column<int>(type: "int", nullable: false),
                    FKEmpleados = table.Column<int>(type: "int", nullable: false),
                    FKLibros = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prestamos_Clientes_FKClientes",
                        column: x => x.FKClientes,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prestamos_Empleados_FKEmpleados",
                        column: x => x.FKEmpleados,
                        principalTable: "Empleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prestamos_Libros_FKLibros",
                        column: x => x.FKLibros,
                        principalTable: "Libros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_FKRol",
                table: "Empleados",
                column: "FKRol");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_FKClientes",
                table: "Prestamos",
                column: "FKClientes");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_FKEmpleados",
                table: "Prestamos",
                column: "FKEmpleados");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_FKLibros",
                table: "Prestamos",
                column: "FKLibros");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prestamos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Libros");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
