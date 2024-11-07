namespace TicketJam.Website.APIClient.DTO
{
    public class OrderLine
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public Ticket Ticket { get; set; }

    }
}
