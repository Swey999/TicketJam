namespace TicketJam.Website.APIClient.DTO
{
    public class CustomerDTO
    {
        public int id {  get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AddressDTO Address { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public int CustomerNo { get; set; }
        public string Password { get; set; }
    }
}
