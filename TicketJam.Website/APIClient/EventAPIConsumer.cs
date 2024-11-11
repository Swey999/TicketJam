using RestSharp;
using TicketJam.Website.APIClient.DTO;

namespace TicketJam.Website.APIClient
{
    public class EventAPIConsumer
    {
        private string BaseURI;
        private RestSharp.RestClient restClient;

        public EventAPIConsumer(string baseURI)
        {
            BaseURI = baseURI;
            this.restClient = new RestSharp.RestClient(baseURI);
        }

        public Event GetEventAndJoinData(int id)
        {
            var client = new RestClient($"{BaseURI}/{id}");

            var response = client.ExecuteGet<Event>(new RestRequest());

            if (!response.IsSuccessful || response == null)
            {
                throw new Exception("Unable to call that thing that thing");
            }

            return response.Data;
        }
        public IEnumerable<Event> GetAll()
        {
            var request = new RestRequest("", Method.Get);

            var response = restClient.Execute<IEnumerable<Event>>(new RestRequest());

            if (!response.IsSuccessful || response == null)
            {
                throw new Exception("Unable to call something something");
            }
            return response.Data;
        }

    }
}
