using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketJam.DAL.Model;

public class Event
{
    public int id { get; set; }
    public string name { get; set; }
    public int eventNo { get; set; }
    public string description { get; set; }
    public int totalAmount { get; set; }
    public DateTime startDate { get; set; }
    public DateTime endDate { get; set; }
    public Venue venueId { get; set; }
    public int organizerId { get; set; }

    public List<Ticket> ticketList { get; set; } = new List<Ticket>();
}
