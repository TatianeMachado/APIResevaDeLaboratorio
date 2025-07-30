using APIResevaDeLaboratorio.Models;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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
    [JsonIgnore]
    public ICollection<Turma> Turmas { get; set; }
    [JsonIgnore]
    public ICollection<Reserva> Reservas { get; set; } 
    [JsonIgnore]
    public ICollection<Laboratorio> Laboratorios { get; set; }
    [JsonIgnore]
    public ICollection<ProfessorTurma> ProfessoresTurmas { get; set; }
}
