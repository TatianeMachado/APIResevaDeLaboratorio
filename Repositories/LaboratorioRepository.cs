using APIResevaDeLaboratorio.Context;
using Microsoft.EntityFrameworkCore;

namespace APIResevaDeLaboratorio.Repositories;

public class LaboratorioRepository : ILaboratorioRepository
{
    private readonly AppDbContext _laboratorioRepository;
    public LaboratorioRepository(AppDbContext context)
    {
        _laboratorioRepository = context;
    }
    public async Task<IEnumerable<Laboratorio>> GetAllAsync()
    {
        return await _laboratorioRepository.Laboratorios.ToListAsync();
    }
    public async Task<Laboratorio?> GetByIdAsync(int id)
    {
        return await _laboratorioRepository.Laboratorios.FindAsync(id);
    }
    public async Task AddAsync(Laboratorio laboratorio)
    {
        _laboratorioRepository.Laboratorios.Add(laboratorio);
        await _laboratorioRepository.SaveChangesAsync();
    }
    public async Task UpdateAsync(Laboratorio laboratorio)
    {
        _laboratorioRepository.Laboratorios.Update(laboratorio);
        await _laboratorioRepository.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        var laboratorio = await GetByIdAsync(id);
        if (laboratorio != null)
        {
            _laboratorioRepository.Laboratorios.Remove(laboratorio);
            await _laboratorioRepository.SaveChangesAsync();
        }
    }
}
