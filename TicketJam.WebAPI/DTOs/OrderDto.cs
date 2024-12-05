using Microsoft.AspNetCore.Mvc;


namespace TicketJam.WebAPI.DTOs
{
    public class OrderDto 
    {
        public int Id { get; set; }
        public int OrderNo { get; set; }
        public int CustomerId { get; set; }

        public IList<OrderLineDto> OrderLines { get; set; } = new List<OrderLineDto>();
    }
}
