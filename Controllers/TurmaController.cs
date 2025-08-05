using APIResevaDeLaboratorio.Repositories;
using Microsoft.AspNetCore.Mvc;
using ReservaDeLaboratorioContext.Models;
using System.Threading.Tasks;

namespace APIResevaDeLaboratorio.Controllers;
[ApiController]
[Route("[controller]")]
public class TurmaController : ControllerBase
{
    private readonly ITurmaRepository _turmaRepository;
    private readonly ILogger<TurmaController> _logger;

    public TurmaController(ILogger<TurmaController> logger, ITurmaRepository turmaRepository)
    {
        _logger = logger;
        _turmaRepository = turmaRepository;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var turmas = await _turmaRepository.GetAllAsync();
        if (turmas is null || !turmas.Any())
        {
            return NotFound();
        }
        return Ok(turmas);
    }
    [HttpGet("{id:int}", Name = "ObterTurma")]
    public async Task<IActionResult> Get(int id)
    {
        var turmas = await _turmaRepository.GetByIdAsync(id);
        if (turmas is null)
        {
            return NotFound();

        }
        return Ok(turmas);
    }
    [HttpPost]  
    public async Task< IActionResult> Post(Turma turma)
    {
        await _turmaRepository.AddAsync(turma);
        if (turma is null)
        {
            return NotFound();
        }
        return new CreatedAtRouteResult("ObterTurma", new  {id= turma.TurmaId }, turma);
    }
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(int id, Turma turma)
    {
        if (id != turma.TurmaId)
        {
            return BadRequest();
        }
        var turmaExistente = await _turmaRepository.GetByIdAsync(id);
        turmaExistente.Nome = turma.Nome;
        turmaExistente.QuantidadeAlunos = turma.QuantidadeAlunos;
        if (turmaExistente is null)
        {
            return NotFound();
        }
        await _turmaRepository.UpdateAsync(turmaExistente);
        return Ok(turmaExistente);
    }

}