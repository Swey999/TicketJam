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
            var client = new RestClient($"{BaseURI}/{id}");

            var response = client.ExecuteGet<Venue>(new RestRequest());

            if (!response.IsSuccessful || response == null)
            {
                throw new Exception("Unable to call that thing that thing");
            }

            return response.Data;
        }
        public IEnumerable<Venue> GetAll()
        {
            var response = restClient.Execute<IEnumerable<Venue>>(new RestRequest());

            if (!response.IsSuccessful || response == null)
            {
                throw new Exception("Unable to call something something");
            }
            return response.Data;
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
