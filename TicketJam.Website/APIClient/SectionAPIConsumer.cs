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
            try
            {
                var request = new RestRequest($"{BaseURI}/{venueId}/sections"); 
                var response = restClient.Execute<IEnumerable<Section>>(request);

                if (response == null || !response.IsSuccessful)
                {
                    throw new Exception($"Unable to fetch sections for venue with ID {venueId}. Error: {response?.StatusDescription}");
                }
                return response.Data;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get Sections by Venue {ex.Message}", ex);
            }
        }

        public Section GetById(int id)
        {
            try
            {
                var client = new RestClient($"{BaseURI}/{id}");

                var response = client.ExecuteGet<Section>(new RestRequest());

                if (!response.IsSuccessful || response == null)
                {
                    throw new Exception($"Unable to fetch sections with ID {id}. Error: {response?.StatusDescription}");
                }

                return response.Data;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get Section By Id {ex.Message}", ex);
            }
        }

        public IEnumerable<Section> GetAll()
        {
            try
            {
                var response = restClient.Execute<IEnumerable<Section>>(new RestRequest());

                if (!response.IsSuccessful || response == null)
                {
                    throw new Exception($"Unable to fetch sections for venue with ID. Error: {response?.StatusDescription}");
                }
                return response.Data;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get all Sections {ex.Message}", ex);
            }
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
