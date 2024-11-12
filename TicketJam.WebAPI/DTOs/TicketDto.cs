namespace TicketJam.WebAPI.DTOs
{
    public class TicketDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string TicketCategory { get; set; }
        public int TicketId { get; set; }
        public DateTime TicketCreated { get; set; }
        public SectionDto Section { get; set; }
        public EventDto Event { get; set; }
    }
}
