using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRMSystem.Migrations
{
    public partial class DoctorProcedureConnect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoctorProcedure",
                columns: table => new
                {
                    DoctorsDoctorId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProceduresProcedureId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorProcedure", x => new { x.DoctorsDoctorId, x.ProceduresProcedureId });
                    table.ForeignKey(
                        name: "FK_DoctorProcedure_Doctors_DoctorsDoctorId",
                        column: x => x.DoctorsDoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorProcedure_Procedures_ProceduresProcedureId",
                        column: x => x.ProceduresProcedureId,
                        principalTable: "Procedures",
                        principalColumn: "ProcedureId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorProcedure_ProceduresProcedureId",
                table: "DoctorProcedure",
                column: "ProceduresProcedureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorProcedure");
        }
    }
}
