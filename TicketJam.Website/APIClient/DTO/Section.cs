namespace TicketJam.Website.APIClient.DTO
{
    public class Section
    {
        public int id { get; set; }
        public string description { get; set; }
        public int ticketAmount { get; set; }
        public Venue venue { get; set; }
    }
}
