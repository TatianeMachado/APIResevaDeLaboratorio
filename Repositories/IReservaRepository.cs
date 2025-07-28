namespace APIResevaDeLaboratorio.Repositories;

public interface IReservaRepository
{
    Task<IEnumerable<Reserva>> GetAllAsync();
    Task<Reserva?> GetByIdAsync(int id);
    Task AddAsync(Reserva reserva);
    Task UpdateAsync(Reserva reserva);
    Task DeleteAsync(int id);
    Task<IEnumerable<Reserva>> GetByLaboratorioAndProfessorAsync(int laboratorioId, int professorId);
    Task<IEnumerable<Reserva>> GetByLaboratorioAndTurmaAsync(int laboratorioId, int turmaId);   
    Task<IEnumerable<Reserva>> GetByProfessorTurmaAndLaboratorioAsync(int professorTurmaId, int laboratorioId);
    Task<IEnumerable<Reserva>> GetByProfessorTurmaAsync(int professorTurmaId);
    Task<IEnumerable<Reserva>> GetByTurmaAsync(int turmaId);
    Task<IEnumerable<Reserva>> GetByProfessorAsync(int professorId);


}
