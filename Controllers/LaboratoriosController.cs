using APIResevaDeLaboratorio.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace APIResevaDeLaboratorio.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LaboratoriosController : ControllerBase
{
    private readonly ILaboratorioRepository _laboratorioRepository;
    private readonly ILogger<LaboratoriosController> _logger;
    public LaboratoriosController(ILaboratorioRepository laboratorioRepository, ILogger<LaboratoriosController> logger)
    {
        _laboratorioRepository = laboratorioRepository;
        _logger = logger;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {

        var laboratorios = await _laboratorioRepository.GetAllAsync();
        if (laboratorios == null || !laboratorios.Any())
        {
            return NotFound("Nenhum laboratório encontrado.");
        }
        return Ok(laboratorios);
    }
    [HttpGet("{id}", Name = "ObterLaboratorio")]
    public async Task<IActionResult> GetById(int id)
    {
        var laboratorio = await _laboratorioRepository.GetByIdAsync(id);
        if (laboratorio == null)
        {
            return NotFound($"Laboratório com ID {id} não encontrado.");
        }
        return Ok(laboratorio);
    }
    [HttpPost]
    public async Task<IActionResult> Create(Laboratorio laboratorio)
    {
        if (laboratorio == null)
        {
            return BadRequest("Dados do laboratório inválidos.");
        }

        await _laboratorioRepository.AddAsync(laboratorio);
        return new CreatedAtRouteResult("ObterLaboratorio", new { id = laboratorio.LaboratorioId }, laboratorio);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Laboratorio laboratorio)
    {
        if (id != laboratorio.LaboratorioId)
        {
            return BadRequest("ID do laboratório não corresponde.");
        }
        var existingLaboratorio = await _laboratorioRepository.GetByIdAsync(id);
        existingLaboratorio.Nome = laboratorio.Nome;
        existingLaboratorio.Capacidade = laboratorio.Capacidade;
        if (existingLaboratorio == null)
        {
            return NotFound($"Laboratório com ID {id} não encontrado.");
        }
        await _laboratorioRepository.UpdateAsync(laboratorio);
        return Ok(existingLaboratorio);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var laboratorio = await _laboratorioRepository.GetByIdAsync(id);
        if (laboratorio == null)
        {
            return NotFound($"Laboratório com ID {id} não encontrado.");
        }
        await _laboratorioRepository.DeleteAsync(id);
        return Ok(laboratorio);
    }

}
