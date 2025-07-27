using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIResevaDeLaboratorio.Migrations
{
    /// <inheritdoc />
    public partial class PopularProfessor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {

            mb.Sql("INSERT INTO Professores (ProfessorId, Nome, Email) VALUES (1, 'Carlos Souza', 'carlos.souza@escola.com')");
            mb.Sql("INSERT INTO Professores (ProfessorId, Nome, Email) VALUES (2, 'Ana Martins', 'ana.martins@escola.com')");
            mb.Sql("INSERT INTO Professores (ProfessorId, Nome, Email) VALUES (3, 'Marcos Lima', 'marcos.lima@escola.com')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Professores WHERE ProfessorId IN (1, 2, 3)");
        }
    }
}
