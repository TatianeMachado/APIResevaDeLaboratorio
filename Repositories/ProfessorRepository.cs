using APIResevaDeLaboratorio.Context;
using Microsoft.EntityFrameworkCore;
using ReservaDeLaboratorioContext.Models;

namespace APIResevaDeLaboratorio.Repositories;

public class ProfessorRepository : IProfessorRepository
{
    private readonly AppDbContext _professorRepository;
    public ProfessorRepository(AppDbContext context)
    {
        _professorRepository = context;
    }
    public async Task<IEnumerable<Professor>> GetAllAsync()
    {
        return await _professorRepository.Professores.ToListAsync();
    }
    public async Task<Professor?> GetByIdAsync(int id)
    {
        return await _professorRepository.Professores.FindAsync(id);
    }
    public async Task AddAsync(Professor professor)
    {
        _professorRepository.Professores.Add(professor);
        await _professorRepository.SaveChangesAsync();
    }
    public async Task UpdateAsync(Professor professor)
    {
        _professorRepository.Professores.Update(professor);
        await _professorRepository.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        var professor = await GetByIdAsync(id);
        if (professor != null)
        {
            _professorRepository.Professores.Remove(professor);
            await _professorRepository.SaveChangesAsync();
        }
    }
}
