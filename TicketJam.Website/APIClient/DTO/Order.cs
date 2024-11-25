namespace TicketJam.Website.APIClient.DTO
{
    public class Order
    {
        public int Id { get; set; }
        public int OrderNo { get; set; }
        public int CustomerId { get; set; }
        public IList<OrderLine> OrderLines { get; set; } = new List<OrderLine>();
    }
}
