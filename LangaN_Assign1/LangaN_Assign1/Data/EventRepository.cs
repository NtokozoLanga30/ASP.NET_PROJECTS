using LangaN_Assign1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace LangaN_Assign1.Data
{


    public class EventRepository : IEventRepository
    {
        private readonly EntityDbContext _appDbContext;

        public EventRepository(EntityDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return _appDbContext.Events;
        }
        public IEnumerable<Attendee> GetAllAttendees()
        {
            return _appDbContext.Attendees;
        }
        public Event GetEventById(int eventId)
        {
            return _appDbContext.Events.FirstOrDefault(e => e.EventId == eventId);
        }

        public Event GetAllAttendeesWithEventDetails(int eventId)
        {
            return _appDbContext.Events
                 .Include(e => e.Attendees)
                 .FirstOrDefault(e => e.EventId == eventId);
        }

        public void AddAttendee(Attendee attendee)
        {
            _appDbContext.Attendees.Add(attendee);
        }

        public void SaveChanges()
        {
            _appDbContext.SaveChanges();
        }

        public Event GetEventWithAttendees(int Registration)
        {
            return _appDbContext.Events
                 .Include(e => e.Attendees)
                 .FirstOrDefault(e => e.EventId == Registration);
        }

        public void AddAttendees(Attendee newRegistration)
        {
            _appDbContext.Attendees.Add(newRegistration);
        }
    }
}
