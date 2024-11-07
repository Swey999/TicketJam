using TicketJam.Website.APIClient.DTO;

namespace TicketJam.Website.APIClient.Stubs.OrderStubs
{
    public class OrderLineStub
    {
        public static TicketStub _ticketStub = new TicketStub();
        public static List<OrderLine> _orderLine = new List<OrderLine>()
        {
            new OrderLine
            () {
            Id = 1,
            Quantity = 1,
            Ticket = _ticketStub.GetById(1)
            }
        };
        public IEnumerable<OrderLine> GetAll()
        {
            return _orderLine;
        }
        public OrderLine GetById(int id)
        {
            return _orderLine.SingleOrDefault(e => e.Id == id);
        }
    }
}
