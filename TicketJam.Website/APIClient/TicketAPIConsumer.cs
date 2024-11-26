using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using TicketJam.Website.APIClient.DTO;

namespace TicketJam.Website.APIClient
{
    public class TicketAPIConsumer : IRestClient<Ticket>
    {
        private string BaseURI;
        private RestClient restClient;
        public TicketAPIConsumer(string baseURI)
        {
            restClient = new RestClient(baseURI);
            BaseURI = baseURI;
        }

        public Ticket Add(Ticket orderToAdd)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ticket> GetAll()
        {
            throw new NotImplementedException();
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

        public Ticket GetTicketWithSectionAndEvent(int id)
        {
            var client = new RestClient($"{BaseURI}/get-ticket-joined/{id}");

            var response = client.ExecuteGet<Ticket>(new RestRequest());

            if (!response.IsSuccessful || response == null)
            {
                throw new Exception("Unable to call that thing that thing");
            }

            return response.Data;
        }

        public Ticket TicketWithSectionAndEvent(int id)
        {
            var client = new RestClient($"{BaseURI}/TicketsFromOrder/{id}");

            var response = client.ExecuteGet<Ticket>(new RestRequest());

            if (!response.IsSuccessful || response == null)
            {
                throw new Exception("Unable to call that thing that thing");
            }

            return response.Data;
        }

        public Ticket Update(Ticket ticketToUpdate)
        {
            // Ensure BaseURI includes the correct base URL
            var client = new RestClient(BaseURI);

            // Append only the ID to the base URL
            var request = new RestRequest($"{ticketToUpdate.Id}")
                .AddJsonBody(ticketToUpdate);

            // Execute the PUT request and get the response
            var response = client.Execute<Ticket>(request, Method.Put);

            // Check if the response is successful
            if (!response.IsSuccessful)
            {
                throw new Exception($"Failed to update Ticket: {response.ErrorMessage}");
            }

            return ticketToUpdate;
        }



    }
}
