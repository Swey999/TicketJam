using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketJam.WinForm.DTO;

namespace TicketJam.WinForm.ApiClient
{
    public class VenueAPIConsumer
    {

        private string _baseURI;
        private RestSharp.RestClient restClient;

        public VenueAPIConsumer(string baseURI)
        {
            _baseURI = baseURI;
            this.restClient = new RestSharp.RestClient(baseURI);
        }

        /// <summary>
        /// Retrieves all venues from database
        /// </summary>
        public IEnumerable<VenueDto> GetVenues()
        {
            var request = new RestRequest("", Method.Get);

            var response = restClient.ExecuteGet<IEnumerable<VenueDto>>(new RestRequest());

            if (!response.IsSuccessful || response == null)
            {
                throw new Exception("Unable to call something something");
            }

            return response.Data;
        }
    }
}
