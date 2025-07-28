using ReservaDeLaboratorioContext.Models;

namespace APIResevaDeLaboratorio.Repositories;

public interface ITurmaRepository
{

    Task<IEnumerable<Turma>> GetAllAsync();
    Task<Turma?> GetByIdAsync(int id);
    Task AddAsync(Turma turma);
    Task UpdateAsync(Turma turma);
    Task DeleteAsync(int id);
}
