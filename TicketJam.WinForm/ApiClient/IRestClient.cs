using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketJam.WinForm.DTO;

namespace TicketJam.WinForm.ApiClient
{
    public interface IRestClient
    {
        IEnumerable<Venue> GetAllVenues();
        
        void CreateEvent(Event Event);

        void AddVenue(Venue venue);

        }
    }
