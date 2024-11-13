using RestSharp;
using TicketJam.Website.APIClient.DTO;

namespace TicketJam.Website.APIClient
{
    public class CustomerAPIConsumer : IRestClient<Customer>
    {
        private string BaseURI;
        private RestClient restClient;
        public CustomerAPIConsumer(string baseURI)
        {
            restClient = new RestClient(baseURI);
            BaseURI = baseURI;
        }

        public Customer Add(Customer OrderToAdd)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Customer GetById(int id)
        {
            var request = new RestRequest($"Customer/{id}", RestSharp.Method.Get);
            var response = restClient.Execute<Customer>(request);
            return response.Data;
        }
        public Customer Update(Customer OrderToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
