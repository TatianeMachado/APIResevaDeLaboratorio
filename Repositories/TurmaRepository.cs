﻿using APIResevaDeLaboratorio.Context;
using ReservaDeLaboratorioContext.Models;

namespace APIResevaDeLaboratorio.Repositories;
public class TurmaRepository : ITurmaRepository
{
    private readonly AppDbContext _turmaRepository;
    public TurmaRepository(AppDbContext context)
    {
        _turmaRepository = context;
    }

    public async Task AddAsync(Turma turma)
    {
        await _turmaRepository.Turmas.AddAsync(turma);
        await _turmaRepository.SaveChangesAsync();


    }

    public async Task DeleteAsync(int id)
    {

        var turma = await GetByIdAsync(id);
        if (turma != null)
        {
            _turmaRepository.Turmas.Remove(turma);
            await _turmaRepository.SaveChangesAsync();
        }
    }

    public Task<IEnumerable<Turma>> GetAllAsync()
    {

        return Task.FromResult(_turmaRepository.Turmas.AsEnumerable());
    }

    public Task<Turma?> GetByIdAsync(int id)
    {


        return _turmaRepository.Turmas.FindAsync(id).AsTask();


    }

    public Task UpdateAsync(Turma turma)
    {

        _turmaRepository.Turmas.Update(turma);
        return _turmaRepository.SaveChangesAsync();


    }
}




     

      
    

