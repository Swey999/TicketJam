namespace TicketJam.Website.APIClient.DTO
{
    public class Event
    {
        public int id { get; set; }
        public string name { get; set; }
        public int eventNo { get; set; }
        public string description { get; set; }
        public int totalAmount { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int venueId { get; set; }

        public List<Ticket> ticketList { get; set; } = new List<Ticket>();
    }
}
