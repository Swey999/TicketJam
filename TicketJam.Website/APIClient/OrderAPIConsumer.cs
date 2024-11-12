using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using RestSharp;
using TicketJam.Website.APIClient.DTO;

namespace TicketJam.Website.APIClient
{
    public class OrderAPIConsumer
    {
            private string BaseURI;
            private RestClient restClient;
            public OrderAPIConsumer(string baseURI)
            {
                restClient = new RestClient(baseURI);
                BaseURI = baseURI;
            }

            public IEnumerable<Order> GetAll()
            {
                var response = restClient.Execute<IEnumerable<Order>>(new RestRequest());

                if (!response.IsSuccessful || response == null)
                {
                    throw new Exception("Unable to call something something");
                }
                return response.Data;
            }

            public Order GetById(int id)
            {
                var client = new RestClient($"{BaseURI}/{id}");

                var response = client.ExecuteGet<Order>(new RestRequest());

                if (!response.IsSuccessful || response == null)
                {
                    throw new Exception("Unable to call that thing that thing");
                }

                return response.Data;
            }

            

            public bool DeleteOrder(int id)
            {
                var request = new RestRequest($"{BaseURI}/{id}", RestSharp.Method.Delete);


                var response = restClient.Execute(request);


                return response.IsSuccessful;
            }

            public Order AddOrder(Order OrderToAdd)
            {

            try
            {
                var request = new RestRequest().AddJsonBody(OrderToAdd);

                var client = new RestClient(BaseURI);

                var response = client.ExecutePost<Order>(request);

                return response.Data;
            }
            catch (Exception ex)
            {

                throw new Exception($"The Order failed to Post{ex.Message}", ex);
            }
            


            }

            public Order UpdateOrder(Order OrderToUpdate)
            {
                var request = new RestRequest().AddJsonBody(OrderToUpdate);

                var client = new RestClient(BaseURI);

                if (client.Put<Order>(request) == null)
                {
                    throw new Exception("Failed to update account");
                }
                return OrderToUpdate;

            }
        }
    }

