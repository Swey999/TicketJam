using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using TicketJam.DAL.Model;

namespace TicketJam.DAL.DAO
{
    public interface ITicketDAO
    {
        public Ticket GetTicketWithSectionAndEvent(int ticketId);
        public Ticket TicketWithSectionAndEvent(int ticketId);

        public void InsertTicketWithEventId(int eventId, Ticket ticket);
    }
}
