using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketJam.DAL.Model;

public class Order
{
    public int id { get; set; }
    public int orderNo {  get; set; }
    public int customerId { get; set; }

    public IList<OrderLine> orderLines { get; set; } = new List<OrderLine>();
}
