using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketJam.DAL.Model;

public class Address
{
    public int Id { get; set; }
    public string StreetName { get; set; }
    public string City { get; set; }
    public string Zip { get; set; }
    public string HouseNo { get; set; }
}
