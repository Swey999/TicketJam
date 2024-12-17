using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketJam.WinForm.DTO;

namespace TicketJam.WinForm.ApiClient
{
    public class OrganizerAPIConsumer
    {
        private string _baseURI;
        private string _baseURILogin;
        private RestSharp.RestClient restClient;

        public OrganizerAPIConsumer(string baseURI, string baseURILogin)
        {
            _baseURI = baseURI;
            _baseURILogin = baseURILogin;
            this.restClient = new RestSharp.RestClient(baseURI);
        }

        /// <summary>
        /// Registers an organizer and adds organizer to JSON for transfer
        /// </summary>
        /// <param name="organizer"></param>
        /// Takes organizer created in Create Organizer 
        /// <exception cref="Exception"></exception>
        /// Throws exception if unable to contact API server
        public OrganizerDto AddOrganizer(OrganizerDto organizer)
        {
            var request = new RestRequest().AddJsonBody(organizer);
            var client = new RestClient(_baseURI);

            var response = client.ExecutePost<OrganizerDto>(request);

            if (!response.IsSuccessful)
            {
                throw new Exception("Failed with connecting to API server");
            }

            return response.Data;
        }

        /// <summary>
        /// Takes organizer login info to attempt to login
        /// </summary>
        /// <param name="organizerDto"></param>
        /// <exception cref="Exception"></exception>
        /// Throws exception if unabble to connect to API server
        public OrganizerDto Login(OrganizerDto organizerDto)
        {
            var request = new RestRequest().AddJsonBody(organizerDto);
            var client = new RestClient(_baseURILogin);

            var response = client.ExecutePost<OrganizerDto>(request);

            if (!response.IsSuccessful)
            {
                throw new Exception("Failed with connecting to API server");
            }

            return response.Data;
        }
    }
}
