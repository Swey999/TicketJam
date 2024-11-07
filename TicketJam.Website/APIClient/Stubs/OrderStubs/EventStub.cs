using Microsoft.EntityFrameworkCore.Storage.Json;
using TicketJam.Website.APIClient.DTO;

namespace TicketJam.Website.APIClient.Stubs.OrderStubs
{
    public class EventStub
    {
        public static VenueStub _venueStub = new VenueStub();
        public static List<Event> _events = new List<Event>()
        {
            new Event
            () {
            Id = 1,
            TotalAmount = 1000,
            EventNo = 10,
            Venue = _venueStub.GetById(1),
            StartDate = DateTime.Now,
            EndDate = DateTime.Today.AddDays(1)
            }
        };
        public IEnumerable<Event> GetAll()
        {
            return _events;
        }

        public Event GetById(int id)
        {
            return _events.SingleOrDefault(e => e.Id == id);
        }
    }
}

