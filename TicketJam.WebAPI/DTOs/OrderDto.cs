using Microsoft.AspNetCore.Mvc;


namespace TicketJam.WebAPI.DTOs
{
    public class OrderDto 
    {
        public int Id { get; set; }
        public int OrderNo { get; set; }
        public CustomerDto Customer { get; set; }
    }
}
