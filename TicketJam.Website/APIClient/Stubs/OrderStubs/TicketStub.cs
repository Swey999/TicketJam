using TicketJam.Website.APIClient.DTO;

namespace TicketJam.Website.APIClient.Stubs.OrderStubs
{
    public class TicketStub
    {
        public static List<Ticket> _tickets = new List<Ticket>()
        {
            new Ticket
            () {
            Id = 1,
            Price = 100,
            TicketCategory = "VIP"
            }
        };
        public IEnumerable<Ticket> GetAll()
        {
            return _tickets;
        }

        public Ticket GetById(int id)
        {
            return _tickets.SingleOrDefault(e => e.Id == id);            
        }
    }
}
