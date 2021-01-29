using Microsoft.EntityFrameworkCore.Migrations;

namespace EjercicioTaller.Migrations
{
    public partial class MigraTaller : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehiculo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Patente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CantidadPuertas = table.Column<int>(type: "int", nullable: true),
                    Cilindrada = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Desperfecto",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManoDeObra = table.Column<int>(type: "int", nullable: false),
                    Tiempo = table.Column<int>(type: "int", nullable: false),
                    VehiculoRefID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desperfecto", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Desperfecto_Vehiculo_VehiculoRefID",
                        column: x => x.VehiculoRefID,
                        principalTable: "Vehiculo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Repuesto",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<int>(type: "int", nullable: false),
                    DesperfectoRefID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repuesto", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Repuesto_Desperfecto_DesperfectoRefID",
                        column: x => x.DesperfectoRefID,
                        principalTable: "Desperfecto",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Desperfecto_VehiculoRefID",
                table: "Desperfecto",
                column: "VehiculoRefID");

            migrationBuilder.CreateIndex(
                name: "IX_Repuesto_DesperfectoRefID",
                table: "Repuesto",
                column: "DesperfectoRefID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Repuesto");

            migrationBuilder.DropTable(
                name: "Desperfecto");

            migrationBuilder.DropTable(
                name: "Vehiculo");
        }
    }
}
