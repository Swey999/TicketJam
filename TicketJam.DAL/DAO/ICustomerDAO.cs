using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketJam.DAL.DAO
{
    public interface ICustomerDAO<Customer>

    {
        int Insert(Customer customer);
        IEnumerable<Customer> GetAll();
        Customer Get(int id);
        bool Update(Customer customer);
        bool Delete(Customer customer);

    }
}
