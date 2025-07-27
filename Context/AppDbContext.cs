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
    public DbSet<ProfessorTurma> ProfessoresTurmas { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Relacionamentos Reserva
        modelBuilder.Entity<Reserva>()
            .HasOne(r => r.Laboratorio)
            .WithMany()
            .HasForeignKey(r => r.LaboratorioId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Reserva>()
            .HasOne(r => r.Turma)
            .WithMany()
            .HasForeignKey(r => r.TurmaId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Reserva>()
            .HasOne(r => r.Professor)
            .WithMany()
            .HasForeignKey(r => r.ProfessorId)
            .OnDelete(DeleteBehavior.Restrict);

        // Relacionamento ProfessorTurma
        modelBuilder.Entity<ProfessorTurma>()
            .HasKey(pt => new { pt.ProfessorId, pt.TurmaId });

        modelBuilder.Entity<ProfessorTurma>()
            .HasOne(pt => pt.Professor)
            .WithMany(p => p.ProfessoresTurmas)
            .HasForeignKey(pt => pt.ProfessorId);

        modelBuilder.Entity<ProfessorTurma>()
            .HasOne(pt => pt.Turma)
            .WithMany(t => t.ProfessoresTurmas)
            .HasForeignKey(pt => pt.TurmaId);

    }
}

