using APIResevaDeLaboratorio.Models;
using Microsoft.EntityFrameworkCore;
using ReservaDeLaboratorioContext.Models;

namespace APIResevaDeLaboratorio.Context;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Laboratorio> Laboratorios { get; set; }
    public DbSet<Professor> Professores { get; set; }
    public DbSet<Reserva> Reservas { get; set; }
    public DbSet<Turma> Turmas { get; set; }

    public DbSet<ProfessorTurma> ProfessorTurmas { get; set; }
    public DbSet<LaboratorioProfessor> LaboratorioProfessores { get; set; }
    public DbSet<LaboratorioTurma> LaboratorioTurmas { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProfessorTurma>()
         .HasKey(pt => new { pt.ProfessorId, pt.TurmaId });

        modelBuilder.Entity<LaboratorioProfessor>()
            .HasKey(lp => new { lp.LaboratorioId, lp.ProfessorId });

        modelBuilder.Entity<LaboratorioTurma>()
            .HasKey(lt => new { lt.LaboratorioId, lt.TurmaId });


    }
}

