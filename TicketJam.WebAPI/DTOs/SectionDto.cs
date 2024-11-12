namespace TicketJam.WebAPI.DTOs
{
    public class SectionDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int TicketAmount { get; set; }
        public VenueDto Venue { get; set; }
    }
}
