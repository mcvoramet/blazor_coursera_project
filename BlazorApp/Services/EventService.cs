using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp.Models;

namespace BlazorApp.Services
{
    public class EventService
    {
        private List<Event> _events;

        public EventService()
        {
            // Initialize with some sample events
            _events = new List<Event>
            {
                new Event
                {
                    Title = "Tech Conference 2024",
                    Description = "Annual technology conference featuring the latest innovations and industry trends.",
                    Date = DateTime.Now.AddDays(30),
                    Location = "San Francisco Convention Center",
                    Capacity = 500,
                    ImageUrl = "images/tech-conference.jpg",
                    IsPublished = true
                },
                new Event
                {
                    Title = "Music Festival",
                    Description = "Three-day music festival featuring top artists from around the world.",
                    Date = DateTime.Now.AddDays(45),
                    Location = "Central Park",
                    Capacity = 2000,
                    ImageUrl = "images/music-festival.jpg",
                    IsPublished = true
                },
                new Event
                {
                    Title = "Charity Run",
                    Description = "Annual 5K run to raise funds for local charities.",
                    Date = DateTime.Now.AddDays(15),
                    Location = "Downtown",
                    Capacity = 300,
                    ImageUrl = "images/charity-run.jpg",
                    IsPublished = true
                }
            };
        }

        public Task<List<Event>> GetEventsAsync()
        {
            return Task.FromResult(_events);
        }

        public Task<Event?> GetEventByIdAsync(Guid id)
        {
            return Task.FromResult(_events.FirstOrDefault(e => e.Id == id));
        }

        public Task<List<Event>> GetPublishedEventsAsync()
        {
            return Task.FromResult(_events.Where(e => e.IsPublished).ToList());
        }

        public Task<bool> CreateEventAsync(Event newEvent)
        {
            try
            {
                _events.Add(newEvent);
                return Task.FromResult(true);
            }
            catch
            {
                return Task.FromResult(false);
            }
        }

        public Task<bool> UpdateEventAsync(Event updatedEvent)
        {
            try
            {
                var existingEvent = _events.FirstOrDefault(e => e.Id == updatedEvent.Id);
                if (existingEvent == null)
                    return Task.FromResult(false);

                // Update the existing event with new values
                existingEvent.Title = updatedEvent.Title;
                existingEvent.Description = updatedEvent.Description;
                existingEvent.Date = updatedEvent.Date;
                existingEvent.Location = updatedEvent.Location;
                existingEvent.Capacity = updatedEvent.Capacity;
                existingEvent.ImageUrl = updatedEvent.ImageUrl;
                existingEvent.IsPublished = updatedEvent.IsPublished;
                existingEvent.UpdatedAt = DateTime.Now;

                return Task.FromResult(true);
            }
            catch
            {
                return Task.FromResult(false);
            }
        }

        public Task<bool> DeleteEventAsync(Guid id)
        {
            try
            {
                var eventToRemove = _events.FirstOrDefault(e => e.Id == id);
                if (eventToRemove == null)
                    return Task.FromResult(false);

                _events.Remove(eventToRemove);
                return Task.FromResult(true);
            }
            catch
            {
                return Task.FromResult(false);
            }
        }

        public Task<bool> PublishEventAsync(Guid id)
        {
            try
            {
                var eventToPublish = _events.FirstOrDefault(e => e.Id == id);
                if (eventToPublish == null)
                    return Task.FromResult(false);

                eventToPublish.IsPublished = true;
                eventToPublish.UpdatedAt = DateTime.Now;
                return Task.FromResult(true);
            }
            catch
            {
                return Task.FromResult(false);
            }
        }
    }
}
