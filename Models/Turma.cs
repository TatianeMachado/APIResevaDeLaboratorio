using APIResevaDeLaboratorio.Models;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;


namespace ReservaDeLaboratorioContext.Models;

public class Turma
{
    public Turma()
    {
        Reservas = new Collection<Reserva>();
        ProfessorTurmas = new Collection<ProfessorTurma>();
        Reservas =new Collection<Reserva>();



    }

    public int TurmaId { get; set; }
    public string Nome { get; set; }
    public int QuantidadeAlunos { get; set; }
    [JsonIgnore]
    public ICollection<ProfessorTurma>? ProfessorTurmas { get; set; }
    [JsonIgnore]
    public ICollection<LaboratorioTurma>? LaboratorioTurmas { get; set; }
    [JsonIgnore]
    public ICollection<Reserva>? Reservas { get; set; }

}
