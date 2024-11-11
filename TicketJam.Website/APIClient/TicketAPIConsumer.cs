using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using TicketJam.Website.APIClient.DTO;

namespace TicketJam.Website.APIClient
{
    public class TicketAPIConsumer : Controller
    {
        private string BaseURI;
        private RestClient restClient;
        public TicketAPIConsumer(string baseURI)
        {
            restClient = new RestClient(baseURI);
            BaseURI = baseURI;
        }
        public Ticket GetById(int id)
        {
            var client = new RestClient($"{BaseURI}/{id}");

            var response = client.ExecuteGet<Ticket>(new RestRequest());

            if (!response.IsSuccessful || response == null)
            {
                throw new Exception("Unable to call that thing that thing");
            }

            return response.Data;
        }
    }
}
