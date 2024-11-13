using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketJam.DAL.Model;

public class Ticket
{
    public int id { get; set; }
    public string description { get; set; }
    public float price { get; set; }
    public string ticketCategory { get; set; }

    public int ticketId { get; set; }
    public DateTime timeCreated { get; set; }
    public Section section { get; set; }
    public Event events { get; set; }
}
