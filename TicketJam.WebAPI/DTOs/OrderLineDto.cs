namespace TicketJam.WebAPI.DTOs
{
    public class OrderLineDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public TicketDto Ticket { get; set; }
    }
}
