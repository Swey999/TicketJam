﻿using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketJam.WinForm.DTO;

namespace TicketJam.WinForm.ApiClient
{
    public class TicketApiConsumer
    {
        private string _baseURI;
        private RestSharp.RestClient restClient;

        public TicketApiConsumer(string baseURI)
        {
            _baseURI = baseURI;
            this.restClient = new RestSharp.RestClient(baseURI);
        }
        /// <summary>
        /// Retrieves all tickets - Is no longer used
        /// </summary>
        public IEnumerable<TicketDto> GetTickets()
        {
            var request = new RestRequest("", Method.Get);

            var response = restClient.ExecuteGet<IEnumerable<TicketDto>>(new RestRequest());

            if(!response.IsSuccessful || response == null)
            {
                throw new Exception($"Unable to get all ticket");
            }

            return response.Data;
        }
    }
}
