namespace TicketJam.Website.APIClient.DTO
{
    public class Customer
    {
        public int id {  get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public Address address { get; set; }
        public string phoneNo { get; set; }
        public string email { get; set; }
        public int customerNo { get; set; }
        public string password { get; set; }
    }
}
