namespace TicketJam.Website.APIClient.DTO
{
    public class Event
    {
        public int Id { get; set; }
        public int EventNo { get; set; }
        //public string Description { get; set; }
        public int TotalAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Venue Venue { get; set; }
       // public Organizer Organizer { get; set; }
    }
}
