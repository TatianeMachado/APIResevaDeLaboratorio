using System.Collections.ObjectModel;


namespace ReservaDeLaboratorioContext.Models;

public class Turma
{
    public Turma()
    {
        Reservas = new Collection<Reserva>();
        Professores = new Collection<Professor>();
        Laboratorios = new Collection<Laboratorio>();



    }

    public int TurmaId { get; set; }

    
    public string Nome { get; set; } = string.Empty;

   
    public int QuantidadeAlunos { get; set; }
    



    public ICollection<Reserva> Reservas { get; set; }
    public ICollection<Professor> Professores { get; set; }
    public ICollection<Laboratorio> Laboratorios { get; set; }
   
}
