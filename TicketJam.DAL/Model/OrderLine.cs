namespace TicketJam.DAL.Model;

public class OrderLine
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public int TicketId { get; set; }

}