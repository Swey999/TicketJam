using RestSharp;
using TicketJam.Website.APIClient.DTO;

namespace TicketJam.Website.APIClient
{
    public class EventAPIConsumer : IRestClient<Event>
    {
        private string BaseURI;
        private RestSharp.RestClient restClient;

        public EventAPIConsumer(string baseURI)
        {
            BaseURI = baseURI;
            this.restClient = new RestSharp.RestClient(baseURI);
        }

        public IEnumerable<Event> GetAll()
        {
            try
            {
                var request = new RestRequest("", Method.Get);

                var response = restClient.Execute<IEnumerable<Event>>(new RestRequest());

                if (!response.IsSuccessful || response == null)
                {
                    throw new Exception($"Unable to get data from Event {response}");
                }
                return response.Data;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch all Events {ex.Message}", ex);
            }
        }

        public Event GetById(int id)
        {
            try
            {
                var client = new RestClient($"{BaseURI}/{id}");

                var response = client.ExecuteGet<Event>(new RestRequest());

                if (!response.IsSuccessful || response == null)
                {
                    throw new Exception($"Unable to get data from Event by id {response}");
                }
                return response.Data;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch Event by id {ex.Message}", ex);
            }
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Event Add(Event orderToAdd)
        {
            throw new NotImplementedException();
        }

        public Event Update(Event orderToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
