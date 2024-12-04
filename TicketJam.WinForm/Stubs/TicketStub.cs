using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketJam.WinForm.DTO;

namespace TicketJam.WinForm.Stubs
{
    public static class TicketStub
    {
        public static List<TicketDto> ticketLists { get; } = new List<TicketDto>() { new TicketDto() { TicketCategory = "VIP" }, { new TicketDto() { TicketCategory = "Seated" } }, { new TicketDto() { TicketCategory = "Standing" } } };
        public static IEnumerable<TicketDto> GetAllTickets()
        {
            return ticketLists;
        }
    }
}
