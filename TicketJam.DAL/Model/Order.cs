using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketJam.DAL.Model;

public class Order
{
    public int Id { get; set; }
    public int OrderNo {  get; set; }
    public int CustomerId { get; set; }

    public IList<OrderLine> OrderLines { get; set; } = new List<OrderLine>();
}
