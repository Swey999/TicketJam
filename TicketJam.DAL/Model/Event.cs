using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketJam.DAL.Model;

public class Event
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int EventNo { get; set; }
    public string Description { get; set; }
    public int TotalAmount { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int VenueId { get; set; }
    public int OrganizerId { get; set; }

    public List<Ticket> TicketList { get; set; } = new List<Ticket>();
}
