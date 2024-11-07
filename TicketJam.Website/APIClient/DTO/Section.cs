namespace TicketJam.Website.APIClient.DTO
{
    public class Section
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int TicketAmount { get; set; }
        public Venue Venue { get; set; }
    }
}
