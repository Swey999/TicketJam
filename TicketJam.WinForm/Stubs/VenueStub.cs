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
        public static List<VenueDto> list { get; } = new List<VenueDto>() { new VenueDto() { Name = "Gigantium", VenueId = 1 }, new VenueDto() { Name = "Elgiganten", VenueId = 2 }, new VenueDto() { Name = "Bilka", VenueId = 3 } };
        public static VenueDto Venue { get; set; } = new VenueDto() { Name = "Gigantium", VenueId = 2 };

        public static IEnumerable<VenueDto> GetAll()
        {
            return list;
        }
    }
}
