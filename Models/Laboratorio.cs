using APIResevaDeLaboratorio.Models;
using ReservaDeLaboratorioContext.Models;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;


public class Laboratorio
{
    public Laboratorio()
    {
        
        Reservas = new Collection<Reserva>();
        LaboratorioProfessores= new Collection<LaboratorioProfessor>();
        LaboratorioTurmas  = new Collection<LaboratorioTurma>();
    }

    public int LaboratorioId { get; set; }
    public string? Nome { get; set; }
    public int Capacidade { get; set; }
    [JsonIgnore]
    public ICollection<LaboratorioProfessor>? LaboratorioProfessores { get; set; }
    [JsonIgnore]
    public ICollection<LaboratorioTurma>? LaboratorioTurmas { get; set; }
    [JsonIgnore]
    public ICollection<Reserva>? Reservas { get; set; }


}