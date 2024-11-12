namespace TicketJam.WebAPI.DTOs
{
    public class CustomerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AddressDto Address { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
    }
}
