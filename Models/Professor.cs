using APIResevaDeLaboratorio.Models;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ReservaDeLaboratorioContext.Models;

public class Professor
{
    
    public Professor() {
       
        Reservas = new Collection<Reserva>();
        ProfessorTurmas = new Collection<ProfessorTurma>();
        LaboratorioProfessores = new Collection<LaboratorioProfessor>();
    }

    public int ProfessorId { get; set; }
    public string? Nome { get; set; }
    public string? Email { get; set; }
    [JsonIgnore]
    public ICollection<ProfessorTurma>? ProfessorTurmas { get; set; }
    [JsonIgnore]
    public ICollection<LaboratorioProfessor>? LaboratorioProfessores { get; set; }
    [JsonIgnore]
    public ICollection<Reserva>? Reservas { get; set; }

}
