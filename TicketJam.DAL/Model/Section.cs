using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketJam.DAL.Model;

public class Section
{
    public int Id { get; set; }
    public string Description { get; set; }
    public int TicketAmount { get; set; }
    public Venue Venue { get; set; }

}
