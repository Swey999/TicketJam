using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using TicketJam.WinForm.DTO;

namespace TicketJam.WinForm.ApiClient
{
    public class EventAPIConsumer
    {
        private string BaseURI;
        private RestSharp.RestClient restClient;

        public EventAPIConsumer(string baseURI)
        {
            BaseURI = baseURI;
            this.restClient = new RestSharp.RestClient(baseURI);
        }

        public Event AddEvent (Event Event)
        {
            var request = new RestRequest().AddJsonBody(Event);
            var client = new RestClient(BaseURI);

            var response = client.ExecutePost<Event>(request);

            if (!response.IsSuccessful)
            {
                throw new Exception("Fail");
            }

            return response.Data;
        }
    }
}
