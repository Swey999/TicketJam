namespace TicketJam.Website.APIClient.DTO
{
    public class Venue
    {
        public int id { get; set; }
        public Address address { get; set; }
        public string name { get; set; }

        public IList<Section> sections { get; set; } = new List<Section>();
    }
}
