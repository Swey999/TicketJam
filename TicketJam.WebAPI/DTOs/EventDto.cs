namespace TicketJam.WebAPI.DTOs
{
    public class EventDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int TotalAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public VenueDto VenueId { get; set; }
        public int OrganizerId { get; set; }

    }
}
