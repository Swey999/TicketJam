using Azure;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using RestSharp;
using System.Text.Json;
using TicketJam.Website.APIClient.DTO;

namespace TicketJam.Website.APIClient;

public class OrderAPIConsumer : IRestClient<Order>
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
        try
        {
            var response = restClient.Execute<IEnumerable<Order>>(new RestRequest());

            if (!response.IsSuccessful || response == null)
            {
                throw new Exception($"Unable to get data from Orders {response}");
            }
            return response.Data;
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to fetch Orders {ex.Message}", ex);
        }
    }

    public Order GetById(int id)
    {
        try
        {
            var client = new RestClient($"{BaseURI}/{id}");

            var response = client.ExecuteGet<Order>(new RestRequest());

            if (!response.IsSuccessful || response == null)
            {
                throw new Exception($"Unable to get data from Order by id {response}");
            }

            return response.Data;
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to fetch Order by id {ex.Message}", ex);
        }
    }



    public bool Delete(int id)
    {
        try
        {
            var request = new RestRequest($"{BaseURI}/{id}", RestSharp.Method.Delete);
            var response = restClient.Execute(request);
            return response.IsSuccessful;
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to delete Order by id {ex.Message}", ex);
        }
    }

    public Order Add(Order orderToAdd)
    {

        try
        {
            var request = new RestRequest().AddJsonBody(orderToAdd);

            var client = new RestClient(BaseURI);

            var response = client.ExecutePost<Order>(request);

            return response.Data;
        }
        catch (Exception ex)
        {
            throw new Exception($"The Order failed to Post{ex.Message}", ex);
        }
    }

    public IEnumerable<Order> GetOrdersByCustomer(int customerId)
    {
        try
        {
            var client = new RestClient($"{BaseURI}/orders/{customerId}/purchases");
            var response = client.Execute<IEnumerable<Order>>(new RestRequest());

            if (!response.IsSuccessful || response.Data == null)
            {
                throw new Exception("Unable to fetch orders for the customer.");
            }

            return response.Data;
        }
        catch (Exception ex)
        {

            throw new Exception($"Failed to fetch orders by customer {ex.Message}", ex);
        }
    }

    public Order Update(Order orderToUpdate)
    {
        try
        {
            var request = new RestRequest().AddJsonBody(orderToUpdate);

            var client = new RestClient(BaseURI);

            if (client.Put<Order>(request) == null)
            {
                throw new Exception("Failed to update account");
            }
            return orderToUpdate;
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to Update order {ex.Message}", ex);
        }


    }

    
}


