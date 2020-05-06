using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorMaestroDetalle.Server.Migrations
{
    public partial class AgregandoColumanEstudianteId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Direcciones_Estudiantes_EstudianteId",
                table: "Direcciones");

            migrationBuilder.AlterColumn<int>(
                name: "EstudianteId",
                table: "Direcciones",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Direcciones_Estudiantes_EstudianteId",
                table: "Direcciones",
                column: "EstudianteId",
                principalTable: "Estudiantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Direcciones_Estudiantes_EstudianteId",
                table: "Direcciones");

            migrationBuilder.AlterColumn<int>(
                name: "EstudianteId",
                table: "Direcciones",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Direcciones_Estudiantes_EstudianteId",
                table: "Direcciones",
                column: "EstudianteId",
                principalTable: "Estudiantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
