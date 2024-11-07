using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketJam.WinForm.DTO;

namespace TicketJam.WinForm.Stubs
{
    public static class VenueStub
    {
        public static List<Venue> list { get; } = new List<Venue>() { new Venue() { Name = "Gigantium" }, new Venue() { Name = "Elgiganten" }, new Venue() { Name = "Bilka" } };
        public static Venue Venue { get; set; } = new Venue() { Name = "Gigantium" };

        public static IEnumerable<Venue> GetAll()
        {
            return list;
        }
    }
}
