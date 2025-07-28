using APIResevaDeLaboratorio.Context;
using Microsoft.EntityFrameworkCore;

namespace APIResevaDeLaboratorio.Repositories;

public class ReservaRepository : IReservaRepository
{
    private readonly AppDbContext _reservaRepository;
    public ReservaRepository(AppDbContext context)
    {
        _reservaRepository = context;
    }
    public async Task<IEnumerable<Reserva>> GetAllAsync()
    {
        return await _reservaRepository.Reservas.ToListAsync();
    }
    public async Task<Reserva?> GetByIdAsync(int id)
    {
        return await _reservaRepository.Reservas.FindAsync(id);
    }
    public async Task AddAsync(Reserva reserva)
    {
        await _reservaRepository.Reservas.AddAsync(reserva);
        await _reservaRepository.SaveChangesAsync();
    }
    public async Task UpdateAsync(Reserva reserva)
    {
        _reservaRepository.Reservas.Update(reserva);
        await _reservaRepository.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        var reserva = await GetByIdAsync(id);
        if (reserva != null)
        {
            _reservaRepository.Reservas.Remove(reserva);
            await _reservaRepository.SaveChangesAsync();
        }
    }
    public async Task<IEnumerable<Reserva>> GetByProfessorIdAsync(int professorId)
    {
        return await _reservaRepository.Reservas
            .Where(r => r.ProfessorId == professorId)
            .ToListAsync();
    }
    public async Task<IEnumerable<Reserva>> GetByLaboratorioIdAsync(int laboratorioId)
    {
        return await _reservaRepository.Reservas
            .Where(r => r.LaboratorioId == laboratorioId)
            .ToListAsync();
    }
    public async Task<IEnumerable<Reserva>> GetByTurmaIdAsync(int turmaId)
    {
        return await _reservaRepository.Reservas
            .Where(r => r.TurmaId == turmaId)
            .ToListAsync();
    }
  
    public async Task<IEnumerable<Reserva>> GetByProfessorAndLaboratorioAsync(int professorId, int laboratorioId)
    {
        return await _reservaRepository.Reservas
            .Where(r => r.ProfessorId == professorId && r.LaboratorioId == laboratorioId)
            .ToListAsync();
    }


    public async Task<IEnumerable<Reserva>> GetByProfessorAndTurmaAsync(int professorId, int turmaId)
    {
        return await _reservaRepository.Reservas
            .Where(r => r.ProfessorId == professorId && r.TurmaId == turmaId)
            .ToListAsync();
    }
    public async Task<IEnumerable<Reserva>> GetByLaboratorioAndTurmaAsync(int laboratorioId, int turmaId)
    {
        return await _reservaRepository.Reservas
            .Where(r => r.LaboratorioId == laboratorioId && r.TurmaId == turmaId)
            .ToListAsync();
    }
    public async Task<IEnumerable<Reserva>> GetByProfessorLaboratorioAndTurmaAsync(int professorId, int laboratorioId, int turmaId)
    {
        return await _reservaRepository.Reservas
            .Where(r => r.ProfessorId == professorId && r.LaboratorioId == laboratorioId && r.TurmaId == turmaId)
            .ToListAsync();
    }   

    public Task<IEnumerable<Reserva>> GetByLaboratorioAndProfessorAsync(int laboratorioId, int professorId)
    {
        _reservaRepository.Reservas
            .Where(r => r.LaboratorioId == laboratorioId && r.ProfessorId == professorId);
        return Task.FromResult<IEnumerable<Reserva>>(new List<Reserva>());

    }

    public Task<IEnumerable<Reserva>> GetByProfessorTurmaAndLaboratorioAsync(int professorTurmaId, int laboratorioId)
    {
        _reservaRepository.Reservas
            .Where(r => r.ProfessorId == professorTurmaId && r.LaboratorioId == laboratorioId);

        return Task.FromResult<IEnumerable<Reserva>>(new List<Reserva>()); // Placeholder for actual implementation
        

    }

    public Task<IEnumerable<Reserva>> GetByProfessorTurmaAsync(int professorTurmaId)
    {

            
        _reservaRepository.Reservas
            .Where(r => r.ProfessorId == professorTurmaId);
        return Task.FromResult<IEnumerable<Reserva>>(new List<Reserva>()); // Placeholder for actual implementation





    }

    public Task<IEnumerable<Reserva>> GetByTurmaAsync(int turmaId)
    {
       _reservaRepository.Reservas
            .Where(r => r.TurmaId == turmaId);
        throw new NotImplementedException();

    }

    public Task<IEnumerable<Reserva>> GetByProfessorAsync(int professorId)
    {
        _reservaRepository.Reservas
            .Where(r => r.ProfessorId == professorId);
        return Task.FromResult<IEnumerable<Reserva>>(new List<Reserva>());

    }
}
