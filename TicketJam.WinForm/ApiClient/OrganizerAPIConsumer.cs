using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketJam.WinForm.DTO;

namespace TicketJam.WinForm.ApiClient
{
    public class OrganizerAPIConsumer
    {
        private string BaseURI;
        private RestSharp.RestClient restClient;

        public OrganizerAPIConsumer(string baseURI)
        {
            BaseURI = baseURI;
            this.restClient = new RestSharp.RestClient(baseURI);
        }

        public OrganizerDto AddEvent(OrganizerDto organizer)
        {
            var request = new RestRequest().AddJsonBody(organizer);
            var client = new RestClient(BaseURI);

            var response = client.ExecutePost<OrganizerDto>(request);

            if (!response.IsSuccessful)
            {
                throw new Exception("Failed with connecting to API server");
            }

            return response.Data;
        }


    }
}
