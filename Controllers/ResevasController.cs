using APIResevaDeLaboratorio.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace APIResevaDeLaboratorio.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ResevasController : ControllerBase
{
    private readonly ILogger<ResevasController> _logger;
    private readonly IReservaRepository _reservaRepository;
    public ResevasController(ILogger<ResevasController> logger, IReservaRepository reservaRepository)
    {
        _logger = logger;
        _reservaRepository = reservaRepository;
    }
    // GET: api/Resevas
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        // Implement logic to retrieve reservations
        var reservas= await _reservaRepository.GetAllAsync();
        if (reservas == null ) {
            return NotFound();
        }
        return Ok(reservas);
    }
    // GET: api/Resevas/5
    [HttpGet("{id}", Name ="ObeterReserva")]
    public async Task< IActionResult> Get(int id)
    {
        // Implement logic to retrieve a reservation by id
       var reserva = await _reservaRepository.GetByIdAsync(id);
        if (reserva == null)
        {
            return NotFound();
        }
        return Ok(reserva);
    }
    // POST: api/Resevas
    [HttpPost]
    public async Task<IActionResult> Post(Reserva reserva)
    {
        // Implement logic to create a new reservation
        if(reserva == null)
        {
            return BadRequest("Reserva cannot be null");
        }
        await _reservaRepository.AddAsync(reserva);
        return new CreatedAtRouteResult("ObterReserva", new { id = reserva.ReservaId }, reserva);

    }
    // PUT: api/Resevas/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] string value)
    {
        // Implement logic to update a reservation by id
        return NoContent();
    }
    // DELETE: api/Resevas/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        // Implement logic to delete a reservation by id
        return NoContent();
    }
}
