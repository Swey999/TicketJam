using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketJam.DAL.Model;

public class Section
{
    public int id { get; set; }
    public string description { get; set; }
    public int ticketAmount { get; set; }
    public Venue venue { get; set; }

}
