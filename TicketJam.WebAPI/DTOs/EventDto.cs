namespace TicketJam.WebAPI.DTOs
{
    public class EventDto
    {
        public string Description { get; set; }
        public int TotalAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public VenueDto Venue { get; set; }
        public OrganizerDto Organizer { get; set; }

    }
}
