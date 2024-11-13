namespace TicketJam.Website.APIClient.DTO
{
    public class Order
    {
        public int id { get; set; }
        public int orderNo { get; set; }
        public int customerId { get; set; }


        public IList<OrderLine> orderLines { get; set; } = new List<OrderLine>();
    }
}
