using APIResevaDeLaboratorio.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ReservaDeLaboratorioContext.Models;
using System.Threading.Tasks;

namespace APIResevaDeLaboratorio.Controllers;
[ApiController]
[Route("[controller]")]
public class ProfessoresController : ControllerBase

{
    private readonly ILogger<ProfessoresController> _logger;
    private readonly IProfessorRepository _professorRepository;
    public ProfessoresController(ILogger<ProfessoresController> logger, IProfessorRepository professorRepository)
    {
        _logger = logger;
        _professorRepository = professorRepository;

    }
   

    [HttpGet(Name = "GetProfessores")]
    public async Task<IActionResult> Get()
    {
        var professores = await _professorRepository.GetAllAsync();
        if (professores == null || !professores.Any())
        {
            return NotFound();
        }
        return Ok(professores);



    }
    [HttpGet("{id:int}", Name = "ObterProfessor")]
    public async Task<IActionResult> GetById(int id)
    {
await _professorRepository.GetByIdAsync(id);
        var professor =await _professorRepository.GetByIdAsync(id);
        if (professor == null)
        {
            return NotFound();
        }
        return Ok(professor);   


    }
    [HttpPost]
    public async Task<IActionResult> CriarProfessor(Professor professor)
    {
         await _professorRepository.AddAsync(professor);
        if (professor is null)
        {
            NotFound("Não pode ser criado");
        }

        return new CreatedAtRouteResult("ObterProfwssor", new {id= professor.ProfessorId },professor);




    }
    [HttpPut("{id:int}")]
    public async Task<IActionResult> AtualizarProfessor(int id, Professor professor)
    {
        if (id != professor.ProfessorId)
        {
            return BadRequest("Id do professor não corresponde ao id da rota");
        }
        var existingProfessor = await _professorRepository.GetByIdAsync(id);
        existingProfessor.Nome = professor.Nome;
        existingProfessor.Email = professor.Email;

        if (existingProfessor == null)
        {
            return NotFound("Professor não encontrado");
        }
      await  _professorRepository.UpdateAsync(existingProfessor);
        return Ok(existingProfessor);
        

    }
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeletarProfessor(int id)
    {
        var professor = await _professorRepository.GetByIdAsync(id);
        if (professor == null)
        {
            return NotFound("Professor não encontrado");
        }
        await _professorRepository.DeleteAsync(id);
        return Ok(professor);
    }
}
