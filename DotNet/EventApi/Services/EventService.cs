using EventApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EventApi.Services
{
    public class EventService : IEventService
    {
        private static List<Event> _events = new List<Event>();

        // Get all events
        public IEnumerable<Event> GetAllEvents()
        {
            return _events;
        }

        // Get a single event by ID
        public Event GetEventById(int id)
        {
            return _events.FirstOrDefault(e => e.Id == id);
        }

        // Add a new event
        public Event AddEvent(Event eventItem)
        {
            if (eventItem == null)
                throw new ArgumentNullException(nameof(eventItem));

            eventItem.Id = _events.Count > 0 ? _events.Max(e => e.Id) + 1 : 1;
            _events.Add(eventItem);
            return eventItem;
        }

        // Update an existing event
        public bool UpdateEvent(int id, Event eventItem)
        {
            var existingEvent = _events.FirstOrDefault(e => e.Id == id);
            if (existingEvent == null)
            {
                return false;
            }

            existingEvent.Name = eventItem.Name;
            existingEvent.Description = eventItem.Description;
            existingEvent.Date = eventItem.Date;

            return true;
        }

        // Delete an event
        public bool DeleteEvent(int id)
        {
            var eventToDelete = _events.FirstOrDefault(e => e.Id == id);
            if (eventToDelete == null)
            {
                return false;
            }

            _events.Remove(eventToDelete);
            return true;
        }
    }
}
