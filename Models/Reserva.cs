using ReservaDeLaboratorioContext.Models;
using System.Text.Json.Serialization;

public class Reserva
{


    public int ReservaId { get; set; }
    public DateTime Data { get; set; }
    public TimeSpan HoraInicio { get; set; }
    public int DuracaoEmMinutos { get; set; }
  
    public int LaboratorioId { get; set; }
   
    public Laboratorio? Laboratorio { get; set; }
    
    public int TurmaId { get; set; }
    
    public Turma? Turma { get; set; }
   
    public int ProfessorId { get; set; }
   
    public Professor? Professor { get; set; }

}