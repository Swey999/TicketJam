using RestSharp;
using TicketJam.Website.APIClient.DTO;

namespace TicketJam.Website.APIClient
{
    public class VenueAPIConsumer : IRestClient<Venue>
    {
        private string BaseURI;
        private RestClient restClient;
        public VenueAPIConsumer(string baseURI)
        {
            restClient = new RestClient(baseURI);
            BaseURI = baseURI;
        }
        public Venue GetById(int id)
        {
            try
            {
                var client = new RestClient($"{BaseURI}/{id}");

                var response = client.ExecuteGet<Venue>(new RestRequest());

                if (!response.IsSuccessful || response == null)
                {
                    throw new Exception($"Unable to fetch venue by id {id}. Error: {response?.StatusDescription}");
                }

                return response.Data;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get venue by id {ex.Message}", ex);
            }
        }
        public IEnumerable<Venue> GetAll()
        {
            try
            {
                var response = restClient.Execute<IEnumerable<Venue>>(new RestRequest());

                if (!response.IsSuccessful || response == null)
                {
                    throw new Exception($"Unable to fetch all Venues. Error: {response?.StatusDescription}");
                }
                return response.Data;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get all venues {ex.Message}", ex);
            }
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Venue Add(Venue orderToAdd)
        {
            throw new NotImplementedException();
        }

        public Venue Update(Venue orderToUpdate)
        {
            throw new NotImplementedException();
        }


    }
}
