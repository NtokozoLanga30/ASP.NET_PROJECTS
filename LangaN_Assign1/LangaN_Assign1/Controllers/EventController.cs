using LangaN_Assign1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LangaN_Assign1.Controllers
{
    public class EventController : Controller
    {

        private readonly EntityDbContext _context;

        public EventController(EntityDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Events.ToListAsync());
        }

        public async Task<IActionResult> Details(int? eventId)
        {
            if (eventId == null)
            {
                return NotFound();
            }

            var @event = await _context.Events
                .FirstOrDefaultAsync(m => m.EventId == eventId);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }
    }
}
