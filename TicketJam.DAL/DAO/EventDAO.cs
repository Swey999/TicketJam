using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketJam.DAL.Model;

namespace TicketJam.DAL.DAO
{
    public class EventDAO : IEventDAO
    {
        public IEnumerable<Venue> GetAllVenues()
        {
            throw new NotImplementedException();
        }

        public Event GetEvent(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertEvent(Event Event)
        {
            throw new NotImplementedException();
        }
    }
}
