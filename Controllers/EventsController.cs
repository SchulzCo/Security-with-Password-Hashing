using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Security_with_Password_Hashing.Models;

namespace Security_with_Password_Hashing.Controllers
{

[ApiController]
[Route("api/events")]
public class EventsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context) => _context = context;

        [HttpGet]
    public IActionResult GetEvents()
    {
        var events = _context.Events.ToList();
        return Ok(events);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult CreateEvent(Event newEvent)
    {
        _context.Events.Add(newEvent);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetEvents), new { id = newEvent.EventId }, newEvent);
    }
}
}