using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketJam.DAL.Model;

public class Venue
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Address Address { get; set; }
}
