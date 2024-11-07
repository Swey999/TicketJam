using TicketJam.Website.APIClient.DTO;

namespace TicketJam.Website.APIClient.Stubs.OrderStubs
{
    public class VenueStub
    {
        private static List<Venue> _venues = new List<Venue>()
        {
            new Venue
            () {
            Id = 1,
            Name = "Boxen"
            }
        };
        public IEnumerable<Venue> GetAll()
        {
            return _venues;
        }
        public Venue GetById(int id)
        {
            return _venues.SingleOrDefault(e => e.Id == id);
        }
    }
}
