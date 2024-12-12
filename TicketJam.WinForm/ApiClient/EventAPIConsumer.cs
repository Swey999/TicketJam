using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
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

        /// <summary>
        /// Sends Event to API for insertion into database
        /// </summary>
        /// <returns></returns>
        /// The event with further information, is not currently used
        /// <exception cref="Exception"></exception>
        /// Throws exception if not able to contact API or other error occurs
        public EventDto AddEvent (EventDto eventDto)
        {
            var request = new RestRequest().AddJsonBody(eventDto);
            var client = new RestClient(BaseURI);

            var response = client.ExecutePost<EventDto>(request);

            if (!response.IsSuccessful)
            {
                throw new Exception("Unable to contact API");
            }

            return response.Data;
        }
    }
}
