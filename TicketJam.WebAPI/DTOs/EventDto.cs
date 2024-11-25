namespace TicketJam.WebAPI.DTOs
{
    public class EventDto
    {
        public int Id { get; set; }
        public int EventNo { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TotalAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public VenueDto Venue { get; set; }
        public int OrganizerId { get; set; }

    }
}
