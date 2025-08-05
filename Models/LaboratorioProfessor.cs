using ReservaDeLaboratorioContext.Models;
using System.Text.Json.Serialization;


namespace APIResevaDeLaboratorio.Models;

public class LaboratorioProfessor
{
    public int LaboratorioId { get; set; }
    public Laboratorio? Laboratorio { get; set; }
    [JsonIgnore]
    public int ProfessorId { get; set; }
    [JsonIgnore]
    public Professor? Professor { get; set; }

}
