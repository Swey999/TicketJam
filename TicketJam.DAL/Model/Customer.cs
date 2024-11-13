using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TicketJam.DAL.Model;

public class Customer
{
    public int id { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public Address address { get; set; }
    public string phoneNo { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    

}
