namespace TicketJam.Website.APIClient.DTO
{
    public class Order
    {
        public int Id { get; set; }
        public int OrderNo { get; set; }
        public CustomerDog Customer { get; set; }
        public Event Event { get; set; }
        public Venue Venue { get; set; }

        public IList<OrderLine> OrderLines { get; set; } = new List<OrderLine>();
    }
}
