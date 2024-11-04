namespace TicketJam.DAL.Model;

public class OrderLine
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public Ticket Ticket { get; set; }
    public Order Order { get; set; }

}