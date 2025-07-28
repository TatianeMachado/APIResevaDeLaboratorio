using APIResevaDeLaboratorio.Models;

namespace APIResevaDeLaboratorio.Repositories
{
    public interface IProfessorTurmaRepository
    {
        Task<IEnumerable<ProfessorTurma>> GetAllAsync();
        Task<ProfessorTurma?> GetByIdAsync(int id);
        Task AddAsync(ProfessorTurma professorTurma);
        Task UpdateAsync(ProfessorTurma professorTurma);
        Task DeleteAsync(int id);


    }
}
