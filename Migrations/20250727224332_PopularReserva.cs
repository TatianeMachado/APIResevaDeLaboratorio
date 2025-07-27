using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIResevaDeLaboratorio.Migrations
{
    /// <inheritdoc />
    public partial class PopularReserva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Reservas (ReservaId, Data, HoraInicio, DuracaoEmMinutos, LaboratorioId, TurmaId, ProfessorId) " +
       "VALUES (1, '2025-07-28', '08:00:00', 90, 1, 1, 1)");

            mb.Sql("INSERT INTO Reservas (ReservaId, Data, HoraInicio, DuracaoEmMinutos, LaboratorioId, TurmaId, ProfessorId) " +
                   "VALUES (2, '2025-07-29', '10:00:00', 60, 2, 2, 2)");

            mb.Sql("INSERT INTO Reservas (ReservaId, Data, HoraInicio, DuracaoEmMinutos, LaboratorioId, TurmaId, ProfessorId) " +
                   "VALUES (3, '2025-07-30', '14:00:00', 120, 3, 3, 3)");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Reservas WHERE ReservaId IN (1, 2, 3)");

        }
    }
}
