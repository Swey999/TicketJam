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
        public static List<VenueDto> list { get; } = new List<VenueDto>() { new VenueDto() { Name = "Gigantium" }, new VenueDto() { Name = "Elgiganten" }, new VenueDto() { Name = "Bilka" } };
        public static VenueDto Venue { get; set; } = new VenueDto() { Name = "Gigantium" };

        public static IEnumerable<VenueDto> GetAll()
        {
            return list;
        }
    }
}
