using APIResevaDeLaboratorio.Context;
using APIResevaDeLaboratorio.Models;
using Microsoft.EntityFrameworkCore;

namespace APIResevaDeLaboratorio.Repositories;

public class ProfessorTurmaRepository : IProfessorTurmaRepository
{
    private readonly AppDbContext _professorTurmaRepository;
    public ProfessorTurmaRepository(AppDbContext context)
    {
        _professorTurmaRepository = context;
    }
    public async Task<IEnumerable<ProfessorTurma>> GetAllAsync()
    {
        return await _professorTurmaRepository.ProfessoresTurmas.ToListAsync();
    }
    public async Task<ProfessorTurma?> GetByIdAsync(int id)
    {
        return await _professorTurmaRepository.ProfessoresTurmas.FindAsync(id);
    }
    public async Task AddAsync(ProfessorTurma professorTurma)
    {
        await _professorTurmaRepository.ProfessoresTurmas.AddAsync(professorTurma);
        await _professorTurmaRepository.SaveChangesAsync();
    }
    public async Task UpdateAsync(ProfessorTurma professorTurma)
    {
        _professorTurmaRepository.ProfessoresTurmas.Update(professorTurma);
        await _professorTurmaRepository.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        var professorTurma = await GetByIdAsync(id);
        if (professorTurma != null)
        {
            _professorTurmaRepository.ProfessoresTurmas.Remove(professorTurma);
            await _professorTurmaRepository.SaveChangesAsync();
        }
    }
}
