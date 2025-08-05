using ReservaDeLaboratorioContext.Models;
using System.Text.Json.Serialization;

namespace APIResevaDeLaboratorio.Models;

public class LaboratorioTurma
{
    public int LaboratorioId { get; set; }
    public Laboratorio? Laboratorio { get; set; }

    [JsonIgnore]
    public int TurmaId { get; set; }
    [JsonIgnore]
    public Turma? Turma { get; set; }

}
