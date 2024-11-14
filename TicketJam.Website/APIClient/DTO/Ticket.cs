namespace TicketJam.Website.APIClient.DTO
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string TicketCategory { get; set; }
        public int TicketId { get; set; }
        public DateTime TimeCreated { get; set; }
        public Section Section { get; set; }
        public Event Event { get; set; }
    }
}
