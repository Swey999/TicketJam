using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketJam.DAL.Model;

public class Venue
{
    public int id { get; set; }
    public Address address { get; set; }

    public IList<Section> sections { get; set; } = new List<Section>();
}
