namespace TicketJam.DAL.Model;

public class OrderLine
{
    public int id { get; set; }
    public int quantity { get; set; }
    public int ticketId { get; set; }

}