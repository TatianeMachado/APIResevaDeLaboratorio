using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIResevaDeLaboratorio.Migrations
{
    /// <inheritdoc />
    public partial class InsercaoDados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            // 👩‍🏫 Professores
            mb.Sql(@"
                INSERT INTO Professores (Nome, Email) VALUES
                ('Tatiane Silva', 'tatiane.silva@escola.edu.br'),
                ('Carlos Mendes', 'carlos.mendes@escola.edu.br'),
                ('Fernanda Rocha', 'fernanda.rocha@escola.edu.br');
            ");

            // 🏫 Turmas
            mb.Sql(@"
                INSERT INTO Turmas (Nome, QuantidadeAlunos) VALUES
                ('Turma A - Informática', 25),
                ('Turma B - Redes', 30),
                ('Turma C - Sistemas', 28);
            ");

            // 🧪 Laboratórios
            mb.Sql(@"
                INSERT INTO Laboratorios (Nome, Capacidade) VALUES
                ('Lab 1 - Informática', 30),
                ('Lab 2 - Redes', 25),
                ('Lab 3 - Sistemas', 35);
            ");

            // 🔗 Relacionamentos (usando subqueries para pegar os IDs)
            mb.Sql(@"
                INSERT INTO ProfessorTurmas (ProfessorId, TurmaId)
                SELECT p.ProfessorId, t.TurmaId FROM Professores p, Turmas t
                WHERE (p.Nome = 'Tatiane Silva' AND t.Nome = 'Turma A - Informática')
                   OR (p.Nome = 'Carlos Mendes' AND t.Nome = 'Turma B - Redes')
                   OR (p.Nome = 'Fernanda Rocha' AND t.Nome = 'Turma C - Sistemas')
                   OR (p.Nome = 'Tatiane Silva' AND t.Nome = 'Turma C - Sistemas');
            ");

            mb.Sql(@"
                INSERT INTO LaboratorioProfessores (LaboratorioId, ProfessorId)
                SELECT l.LaboratorioId, p.ProfessorId FROM Laboratorios l, Professores p
                WHERE (l.Nome = 'Lab 1 - Informática' AND p.Nome = 'Tatiane Silva')
                   OR (l.Nome = 'Lab 2 - Redes' AND p.Nome = 'Carlos Mendes')
                   OR (l.Nome = 'Lab 3 - Sistemas' AND p.Nome = 'Fernanda Rocha')
                   OR (l.Nome = 'Lab 3 - Sistemas' AND p.Nome = 'Tatiane Silva');
            ");

            mb.Sql(@"
                INSERT INTO LaboratorioTurmas (LaboratorioId, TurmaId)
                SELECT l.LaboratorioId, t.TurmaId FROM Laboratorios l, Turmas t
                WHERE (l.Nome = 'Lab 1 - Informática' AND t.Nome = 'Turma A - Informática')
                   OR (l.Nome = 'Lab 2 - Redes' AND t.Nome = 'Turma B - Redes')
                   OR (l.Nome = 'Lab 3 - Sistemas' AND t.Nome = 'Turma C - Sistemas')
                   OR (l.Nome = 'Lab 1 - Informática' AND t.Nome = 'Turma C - Sistemas');
            ");

            // 📅 Reservas
            mb.Sql(@"
                INSERT INTO Reservas (Data, HoraInicio, DuracaoEmMinutos, LaboratorioId, TurmaId, ProfessorId)
                SELECT '2025-08-05 08:00:00', '08:00:00', 90, l.LaboratorioId, t.TurmaId, p.ProfessorId
                FROM Laboratorios l, Turmas t, Professores p
                WHERE l.Nome = 'Lab 1 - Informática' AND t.Nome = 'Turma A - Informática' AND p.Nome = 'Tatiane Silva';

                INSERT INTO Reservas (Data, HoraInicio, DuracaoEmMinutos, LaboratorioId, TurmaId, ProfessorId)
                SELECT '2025-08-05 10:00:00', '10:00:00', 60, l.LaboratorioId, t.TurmaId, p.ProfessorId
                FROM Laboratorios l, Turmas t, Professores p
                WHERE l.Nome = 'Lab 2 - Redes' AND t.Nome = 'Turma B - Redes' AND p.Nome = 'Carlos Mendes';

                INSERT INTO Reservas (Data, HoraInicio, DuracaoEmMinutos, LaboratorioId, TurmaId, ProfessorId)
                SELECT '2025-08-06 09:00:00', '09:00:00', 120, l.LaboratorioId, t.TurmaId, p.ProfessorId
                FROM Laboratorios l, Turmas t, Professores p
                WHERE l.Nome = 'Lab 3 - Sistemas' AND t.Nome = 'Turma C - Sistemas' AND p.Nome = 'Fernanda Rocha';

                INSERT INTO Reservas (Data, HoraInicio, DuracaoEmMinutos, LaboratorioId, TurmaId, ProfessorId)
                SELECT '2025-08-06 14:00:00', '14:00:00', 60, l.LaboratorioId, t.TurmaId, p.ProfessorId
                FROM Laboratorios l, Turmas t, Professores p
                WHERE l.Nome = 'Lab 3 - Sistemas' AND t.Nome = 'Turma C - Sistemas' AND p.Nome = 'Tatiane Silva';
            ");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            // Remove reservas
            mb.Sql("DELETE FROM Reservas WHERE Data BETWEEN '2025-08-05' AND '2025-08-06';");

            // Remove relacionamentos
            mb.Sql("DELETE FROM LaboratorioTurmas;");
            mb.Sql("DELETE FROM LaboratorioProfessores;");
            mb.Sql("DELETE FROM ProfessorTurmas;");

            // Remove entidades principais
            mb.Sql("DELETE FROM Laboratorios WHERE Nome LIKE 'Lab%';");
            mb.Sql("DELETE FROM Turmas WHERE Nome LIKE 'Turma%';");
            mb.Sql("DELETE FROM Professores WHERE Email LIKE '%@escola.edu.br';");

        }
    }
}
