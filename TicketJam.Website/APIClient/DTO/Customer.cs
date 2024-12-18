﻿namespace TicketJam.Website.APIClient.DTO
{
    public class Customer
    {
        public int Id {  get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public int CustomerNo { get; set; }
    }
}
