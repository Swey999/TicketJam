using RestSharp;
using TicketJam.Website.APIClient.DTO;

namespace TicketJam.Website.APIClient
{
    public class CustomerAPIConsumer
    {
        private string BaseURI;
        private RestClient restClient;
        public CustomerAPIConsumer(string baseURI)
        {
            restClient = new RestClient(baseURI);
            BaseURI = baseURI;
        }

        public CustomerDTO GetCustomerFromId(int id)
        {
            var request = new RestRequest($"Customer/{id}", RestSharp.Method.Get);
            var response = restClient.Execute<CustomerDTO>(request);
            return response.Data;
        }


    }
}
