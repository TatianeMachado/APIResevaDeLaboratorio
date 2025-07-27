using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIResevaDeLaboratorio.Migrations
{
    /// <inheritdoc />
    public partial class PopularProfessorTurma : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO ProfessorTurma (ProfessoresProfessorId, TurmasTurmaId) VALUES (1, 1)");
            mb.Sql("INSERT INTO ProfessorTurma (ProfessoresProfessorId, TurmasTurmaId) VALUES (2, 2)");
            mb.Sql("INSERT INTO ProfessorTurma (ProfessoresProfessorId, TurmasTurmaId) VALUES (3, 3)");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM ProfessorTurma WHERE ProfessoresProfessorId IN (1,2,3) AND TurmasTurmaId IN (1,2,3)");

        }
    }
}
