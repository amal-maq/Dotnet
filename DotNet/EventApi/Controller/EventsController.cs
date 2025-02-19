using EventApi.Models;
using EventApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace EventApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        // GET: api/events
        [HttpGet]
        public ActionResult<IEnumerable<Event>> GetAllEvents()
        {
            var events = _eventService.GetAllEvents();
            return Ok(events); // 200 OK with the list of events
        }

        // GET: api/events/{id}
        [HttpGet("{id}")]
        public ActionResult<Event> GetEvent(int id)
        {
            var eventItem = _eventService.GetEventById(id);
            if (eventItem == null)
            {
                return NotFound(); // 404 Not Found
            }
            return Ok(eventItem); // 200 OK with the event details
        }

        // POST: api/events
        [HttpPost]
        public ActionResult<Event> CreateEvent([FromBody] Event eventItem)
        {
            if (eventItem == null || string.IsNullOrEmpty(eventItem.Name) || eventItem.Date == default)
            {
                return BadRequest("Invalid input. Name and Date are required."); // 400 Bad Request
            }

            var createdEvent = _eventService.AddEvent(eventItem);
            return CreatedAtAction(nameof(GetEvent), new { id = createdEvent.Id }, createdEvent); // 201 Created
        }

        // PUT: api/events/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateEvent(int id, [FromBody] Event eventItem)
        {
            if (eventItem == null || string.IsNullOrEmpty(eventItem.Name) || eventItem.Date == default)
            {
                return BadRequest("Invalid input. Name and Date are required."); // 400 Bad Request
            }

            var success = _eventService.UpdateEvent(id, eventItem);
            if (!success)
            {
                return NotFound(); // 404 Not Found
            }

            return NoContent(); // 204 No Content
        }

        // DELETE: api/events/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteEvent(int id)
        {
            var success = _eventService.DeleteEvent(id);
            if (!success)
            {
                return NotFound(); // 404 Not Found
            }

            return NoContent(); // 204 No Content
        }
    }
}
