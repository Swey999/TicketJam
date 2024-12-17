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

        public Customer Add(Customer customerToAdd)
        {
            try
            {
                var request = new RestRequest().AddJsonBody(customerToAdd);

                var client = new RestClient(BaseURI);

                var response = client.ExecutePost<Customer>(request);

                return response.Data;
            }
            catch (Exception ex)
            {

                throw new Exception($"The Customer failed to Post{ex.Message}", ex);
            }



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
            try
            {
                var request = new RestRequest($"Customer/{id}", RestSharp.Method.Get);
                var response = restClient.Execute<Customer>(request);
                return response.Data;

            }
            catch (Exception ex)
            {

                throw new Exception($"Failed to fetch Customer By Id {ex.Message}", ex);
            }
        }
        public Customer Update(Customer OrderToUpdate)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerByEmail(string userEmail)
        {
            try
            {
                var encodedEmail = Uri.EscapeDataString(userEmail); // Encodes '@' to '%40'
                var request = new RestRequest($"/by-email/{encodedEmail}", RestSharp.Method.Get);
                var response = restClient.Execute<Customer>(request);
                return response.Data;
            }
            catch (Exception ex)
            {

                throw new Exception($"Failed to fetch Customer By Email {ex.Message}", ex);
            }

        }
    }
}
