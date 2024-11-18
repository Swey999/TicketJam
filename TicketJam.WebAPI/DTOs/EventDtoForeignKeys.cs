namespace TicketJam.WebAPI.DTOs
{
    public class EventDtoForeignKeys
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int TotalAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int VenueId { get; set; }
        public int OrganizerId { get; set; }
    }
}
