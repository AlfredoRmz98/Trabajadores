using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppTrabajadores.Migrations
{
    public partial class Puestos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Trabajadors",
                table: "Trabajadors");

            migrationBuilder.RenameTable(
                name: "Trabajadors",
                newName: "Trabajador");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trabajador",
                table: "Trabajador",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "puestos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Departamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrabajadorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_puestos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_puestos_Trabajador_TrabajadorId",
                        column: x => x.TrabajadorId,
                        principalTable: "Trabajador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_puestos_TrabajadorId",
                table: "puestos",
                column: "TrabajadorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "puestos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trabajador",
                table: "Trabajador");

            migrationBuilder.RenameTable(
                name: "Trabajador",
                newName: "Trabajadors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trabajadors",
                table: "Trabajadors",
                column: "Id");
        }
    }
}
