using APIResevaDeLaboratorio.Models;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ReservaDeLaboratorioContext.Models;

public class Professor
{
    
    public Professor() {
        Turmas = new Collection<Turma>();
        Reservas = new Collection<Reserva>();
        Laboratorios = new Collection<Laboratorio>();
        ProfessoresTurmas = new Collection<ProfessorTurma>();
    }

    public int ProfessorId { get; set; }

    
    public string Nome { get; set; } = string.Empty;

  
    public string Email { get; set; } = string.Empty;

    public ICollection<Turma> Turmas { get; set; } 
    public ICollection<Reserva> Reservas { get; set; } 
    public ICollection<Laboratorio> Laboratorios { get; set; }
    public ICollection<ProfessorTurma> ProfessoresTurmas { get; set; }
}
