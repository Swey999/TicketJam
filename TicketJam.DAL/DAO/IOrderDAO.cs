using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketJam.DAL.Model;

namespace TicketJam.DAL.DAO
{
    public interface IOrderDAO
    {
        IEnumerable<Order> GetOrdersByCustomer(int customerId);
    }
}
