using EventApi.Models;
using System.Collections.Generic;

namespace EventApi.Services
{
    public interface IEventService
    {
        IEnumerable<Event> GetAllEvents();
        Event GetEventById(int id);
        Event AddEvent(Event eventItem);
        bool UpdateEvent(int id, Event eventItem);
        bool DeleteEvent(int id);
    }
}
