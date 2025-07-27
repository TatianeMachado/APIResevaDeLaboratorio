using ReservaDeLaboratorioContext.Models;
using System.Collections.ObjectModel;

public class Laboratorio
{
    public Laboratorio()
    {
        Professores = new Collection<Professor>();
        Reservas = new Collection<Reserva>();
        Turmas = new Collection<Turma>();
    }

    public int LaboratorioId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public int Capacidade { get; set; } = 20;
    public Collection<Professor> Professores { get; set; }
    public Collection <Reserva> Reservas { get;  set; }
    public Collection <Turma> Turmas { get;  set; }

    // Remover se não quiser navegação inversa
    // public ICollection<Reserva> Reservas { get; set; }
}