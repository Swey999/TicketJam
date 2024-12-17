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
            try
            {
                var client = new RestClient($"{BaseURI}/{id}");

                var response = client.ExecuteGet<Ticket>(new RestRequest());

                if (!response.IsSuccessful || response == null)
                {
                    throw new Exception($"Unable to fetch ticket by id {id}. Error: {response?.StatusDescription}");
                }

                return response.Data;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get ticket by id {ex.Message}", ex);
            }
        }

        public Ticket GetTicketWithSectionAndEvent(int id)
        {
            try
            {
            var client = new RestClient($"{BaseURI}/get-ticket-joined/{id}");

            var response = client.ExecuteGet<Ticket>(new RestRequest());

            if (!response.IsSuccessful || response == null)
            {
                    throw new Exception($"Unable to fetch ticket with section and event {id}. Error: {response?.StatusDescription}");
            }

                return response.Data;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get ticket with section and event by id {ex.Message}", ex);
            }
        }

        public Ticket TicketWithSectionAndEvent(int id)
        {
            try
            {
                var client = new RestClient($"{BaseURI}/TicketsFromOrder/{id}");

                var response = client.ExecuteGet<Ticket>(new RestRequest());

                if (!response.IsSuccessful || response == null)
                {
                    throw new Exception($"Unable to fetch ticket with section and event {id}. Error: {response?.StatusDescription}");
                }

                return response.Data;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get ticket with section and event by id {ex.Message}", ex);
            }
        }

        public Ticket Update(Ticket ticketToUpdate)
        {
            try
            {
                var client = new RestClient(BaseURI);
                var request = new RestRequest($"{ticketToUpdate.Id}")
                    .AddJsonBody(ticketToUpdate);
                var response = client.Execute<Ticket>(request, Method.Put);
                if (!response.IsSuccessful)
                {
                    throw new Exception($"Failed to update Ticket: {response.ErrorMessage}");
                }

                return ticketToUpdate;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update ticket {ex.Message}", ex);
            }
        }



    }
}
