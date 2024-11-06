using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketJam.WinForm.DTO;
using TicketJam.WinForm.Stubs;

namespace TicketJam.WinForm.ApiClient
{
    public class RestApiClient : IRestClient
    {
        public void AddVenue(Venue venue)
        {
            throw new NotImplementedException();
        }

        public void CreateEvent(Event Event)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Venue> GetAllVenues()
        {
            return VenueStub.GetAll();
        }
    }
}
