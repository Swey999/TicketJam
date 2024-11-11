﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketJam.DAL.DAO;
using TicketJam.DAL.Model;
using TicketJam.WebAPI.DTOs;
using TicketJam.WebAPI.DTOs.Converters;

namespace TicketJam.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EventController (IEventDAO eventDAO) : Controller
    {

        private readonly IEventDAO _eventDAO = eventDAO; 


        // GET api/<EventControllerAPI>/5
        [HttpGet("{id}")]
        public ActionResult<Event> GetEventAndJoinData(int id)
        {
            Event events = _eventDAO.GetEventAndJoinData(id);
            if (events == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(events);
            }
        }

        [HttpPost]
        public ActionResult<Event> AddEvent (EventDto eventObject)
        {
            int id = _eventDAO.InsertEvent(eventObject.FromDto());
            //returns 201 + account JSON as body
            return Ok(eventObject);
        }

    }
}
