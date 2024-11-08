using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketJam.DAL.Model;

public class Ticket
{
    public int Id { get; set; }
    public string Description { get; set; }
    public float Price { get; set; }
    public string TicketCategory { get; set; }
    public DateTime TicketCreated { get; set; }
    public Section Section { get; set; }
    public Event Event { get; set; }
}
