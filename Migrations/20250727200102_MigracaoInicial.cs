using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIResevaDeLaboratorio.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Laboratorios",
                columns: table => new
                {
                    LaboratorioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Capacidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laboratorios", x => x.LaboratorioId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    ProfessorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.ProfessorId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Turmas",
                columns: table => new
                {
                    TurmaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    QuantidadeAlunos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turmas", x => x.TurmaId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LaboratorioProfessor",
                columns: table => new
                {
                    LaboratoriosLaboratorioId = table.Column<int>(type: "int", nullable: false),
                    ProfessoresProfessorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaboratorioProfessor", x => new { x.LaboratoriosLaboratorioId, x.ProfessoresProfessorId });
                    table.ForeignKey(
                        name: "FK_LaboratorioProfessor_Laboratorios_LaboratoriosLaboratorioId",
                        column: x => x.LaboratoriosLaboratorioId,
                        principalTable: "Laboratorios",
                        principalColumn: "LaboratorioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LaboratorioProfessor_Professores_ProfessoresProfessorId",
                        column: x => x.ProfessoresProfessorId,
                        principalTable: "Professores",
                        principalColumn: "ProfessorId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LaboratorioTurma",
                columns: table => new
                {
                    LaboratoriosLaboratorioId = table.Column<int>(type: "int", nullable: false),
                    TurmasTurmaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaboratorioTurma", x => new { x.LaboratoriosLaboratorioId, x.TurmasTurmaId });
                    table.ForeignKey(
                        name: "FK_LaboratorioTurma_Laboratorios_LaboratoriosLaboratorioId",
                        column: x => x.LaboratoriosLaboratorioId,
                        principalTable: "Laboratorios",
                        principalColumn: "LaboratorioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LaboratorioTurma_Turmas_TurmasTurmaId",
                        column: x => x.TurmasTurmaId,
                        principalTable: "Turmas",
                        principalColumn: "TurmaId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProfessoresTurmas",
                columns: table => new
                {
                    ProfessorId = table.Column<int>(type: "int", nullable: false),
                    TurmaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessoresTurmas", x => new { x.ProfessorId, x.TurmaId });
                    table.ForeignKey(
                        name: "FK_ProfessoresTurmas_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "ProfessorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfessoresTurmas_Turmas_TurmaId",
                        column: x => x.TurmaId,
                        principalTable: "Turmas",
                        principalColumn: "TurmaId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProfessorTurma",
                columns: table => new
                {
                    ProfessoresProfessorId = table.Column<int>(type: "int", nullable: false),
                    TurmasTurmaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessorTurma", x => new { x.ProfessoresProfessorId, x.TurmasTurmaId });
                    table.ForeignKey(
                        name: "FK_ProfessorTurma_Professores_ProfessoresProfessorId",
                        column: x => x.ProfessoresProfessorId,
                        principalTable: "Professores",
                        principalColumn: "ProfessorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfessorTurma_Turmas_TurmasTurmaId",
                        column: x => x.TurmasTurmaId,
                        principalTable: "Turmas",
                        principalColumn: "TurmaId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    ReservaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    HoraInicio = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    DuracaoEmMinutos = table.Column<int>(type: "int", nullable: false),
                    LaboratorioId = table.Column<int>(type: "int", nullable: false),
                    TurmaId = table.Column<int>(type: "int", nullable: false),
                    ProfessorId = table.Column<int>(type: "int", nullable: false),
                    LaboratorioId1 = table.Column<int>(type: "int", nullable: true),
                    ProfessorId1 = table.Column<int>(type: "int", nullable: true),
                    TurmaId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.ReservaId);
                    table.ForeignKey(
                        name: "FK_Reservas_Laboratorios_LaboratorioId",
                        column: x => x.LaboratorioId,
                        principalTable: "Laboratorios",
                        principalColumn: "LaboratorioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservas_Laboratorios_LaboratorioId1",
                        column: x => x.LaboratorioId1,
                        principalTable: "Laboratorios",
                        principalColumn: "LaboratorioId");
                    table.ForeignKey(
                        name: "FK_Reservas_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "ProfessorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservas_Professores_ProfessorId1",
                        column: x => x.ProfessorId1,
                        principalTable: "Professores",
                        principalColumn: "ProfessorId");
                    table.ForeignKey(
                        name: "FK_Reservas_Turmas_TurmaId",
                        column: x => x.TurmaId,
                        principalTable: "Turmas",
                        principalColumn: "TurmaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservas_Turmas_TurmaId1",
                        column: x => x.TurmaId1,
                        principalTable: "Turmas",
                        principalColumn: "TurmaId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratorioProfessor_ProfessoresProfessorId",
                table: "LaboratorioProfessor",
                column: "ProfessoresProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratorioTurma_TurmasTurmaId",
                table: "LaboratorioTurma",
                column: "TurmasTurmaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessoresTurmas_TurmaId",
                table: "ProfessoresTurmas",
                column: "TurmaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorTurma_TurmasTurmaId",
                table: "ProfessorTurma",
                column: "TurmasTurmaId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_LaboratorioId",
                table: "Reservas",
                column: "LaboratorioId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_LaboratorioId1",
                table: "Reservas",
                column: "LaboratorioId1");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_ProfessorId",
                table: "Reservas",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_ProfessorId1",
                table: "Reservas",
                column: "ProfessorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_TurmaId",
                table: "Reservas",
                column: "TurmaId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_TurmaId1",
                table: "Reservas",
                column: "TurmaId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LaboratorioProfessor");

            migrationBuilder.DropTable(
                name: "LaboratorioTurma");

            migrationBuilder.DropTable(
                name: "ProfessoresTurmas");

            migrationBuilder.DropTable(
                name: "ProfessorTurma");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Laboratorios");

            migrationBuilder.DropTable(
                name: "Professores");

            migrationBuilder.DropTable(
                name: "Turmas");
        }
    }
}
