using ReservaDeLaboratorioContext.Models;

namespace APIResevaDeLaboratorio.Repositories;

public interface IProfessorRepository
{
    Task<IEnumerable<Professor>> GetAllAsync();
    Task<Professor?> GetByIdAsync(int id);
    Task AddAsync(Professor professor);
    Task UpdateAsync(Professor professor);
    Task DeleteAsync(int id);
}
