using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketJam.DAL.Model;

public class Address
{
    public int id { get; set; }
    public string streetName { get; set; }
    public string city { get; set; }
    public string zip { get; set; }
    public string houseNo { get; set; }
}
