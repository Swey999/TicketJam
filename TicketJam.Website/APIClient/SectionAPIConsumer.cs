using RestSharp;
using TicketJam.Website.APIClient.DTO;

namespace TicketJam.Website.APIClient
{
    public class SectionAPIConsumer : IRestClient<Section>
    {
        private string BaseURI;
        private RestClient restClient;
        public SectionAPIConsumer(string baseURI)
        {
            restClient = new RestClient(baseURI);
            BaseURI = baseURI;
        }

        public IEnumerable<Section> GetSectionsByVenue(int venueId)
        {
            var request = new RestRequest($"{BaseURI}/{venueId}/sections"); 
            var response = restClient.Execute<IEnumerable<Section>>(request);

            if (response == null || !response.IsSuccessful)
            {
                throw new Exception($"Unable to fetch sections for venue with ID {venueId}. Error: {response?.StatusDescription}");
            }

            return response.Data;
        }

        public Section GetById(int id)
        {
            var client = new RestClient($"{BaseURI}/{id}");

            var response = client.ExecuteGet<Section>(new RestRequest());

            if (!response.IsSuccessful || response == null)
            {
                throw new Exception("Unable to call that thing that thing");
            }

            return response.Data;
        }

        public IEnumerable<Section> GetAll()
        {
            var response = restClient.Execute<IEnumerable<Section>>(new RestRequest());

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

        public Section Add(Section OrderToAdd)
        {
            throw new NotImplementedException();
        }

        public Section Update(Section OrderToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
