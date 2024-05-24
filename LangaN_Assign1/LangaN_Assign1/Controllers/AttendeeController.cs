using LangaN_Assign1.Data;
using LangaN_Assign1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LangaN_Assign1.Controllers
{
    public class AttendeeController : Controller
    {
        private readonly IEventRepository _eventRepository;

        public AttendeeController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        [HttpGet]
        public IActionResult Register(int eventId)
        {
            Event eventDetails = _eventRepository.GetEventById(eventId);

            if (eventDetails == null)
            {
                return NotFound();
            }

            var eventRegistration = new Attendee { EventId = eventId };
            return View(eventRegistration);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Attendee attendee)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    Event Event = _eventRepository.GetEventById(attendee.EventId);

                    if (Event != null)
                    {
                        Event.EventRegistrations++;
                    }

                    _eventRepository.AddAttendees(attendee);
                    _eventRepository.SaveChanges();

                    return RedirectToAction("Confirmation", new { eventId = attendee.EventId });
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
                       "Try again, and if the problem persists, " +
                       "see your system administrator.");
                }
            }
            return View(attendee);
        }
        public IActionResult List(Attendee attendee)
        {
            var Attendee = _eventRepository.GetAllAttendees().ToList();
            return View(Attendee);
        }

        [HttpGet]
        public  IActionResult Confirmation(int eventId)
        {
            Event events = _eventRepository.GetEventWithAttendees(eventId);

            if (events == null)
            {
                return NotFound();
            }
            return View(events);
        }
    }
}
