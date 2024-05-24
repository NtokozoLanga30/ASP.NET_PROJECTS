using LangaN_Assign1.Models;

namespace LangaN_Assign1.Data
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAllEvents();
        Event GetEventById(int eventId);
        IEnumerable<Attendee> GetAllAttendees();
        Event GetEventWithAttendees(int Registration);
        void AddAttendees(Attendee newRegistration);
        void SaveChanges();
    }
}
