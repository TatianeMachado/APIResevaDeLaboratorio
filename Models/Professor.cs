using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ReservaDeLaboratorioContext.Models;

public class Professor
{
    
    public Professor() {
        Turmas = new Collection<Turma>();
        Reservas = new Collection<Reserva>();
        Laboratorios = new Collection<Laboratorio>();
    }

    public int ProfessorId { get; set; }

    
    public string Nome { get; set; } = string.Empty;

  
    public string Email { get; set; } = string.Empty;

    public ICollection<Turma> Turmas { get; set; } = new List<Turma>();
    public ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
    public ICollection<Laboratorio> Laboratorios { get; set; }
}
