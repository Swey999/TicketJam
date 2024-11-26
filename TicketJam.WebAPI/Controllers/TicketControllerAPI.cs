﻿using Microsoft.AspNetCore.Mvc;
using TicketJam.DAL.DAO;
using TicketJam.DAL.Model;
using TicketJam.WebAPI.DTOs;
using TicketJam.WebAPI.DTOs.Converters;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TicketJam.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TicketControllerAPI : ControllerBase
    {

        public IDAO<Ticket> _ticketDAO;
        public ITicketDAO _ITicketDAO;

        public TicketControllerAPI(IDAO<Ticket> iDAO, ITicketDAO iTicketDAO)
        {
            this._ticketDAO = iDAO;
            _ITicketDAO = iTicketDAO;

        }

        // GET: api/<TicketController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TicketController>/5
        [HttpGet("{id}")]
        public ActionResult<Ticket> GetById(int id)
        {
            Ticket ticket = _ticketDAO.GetById(id);
            if (ticket == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ticket);
            }
        }

        [HttpGet("get-ticket-joined/{id}")]
        public ActionResult<TicketDto> GetTicketWithSectionAndEvent(int Id)
        {
            TicketDto ticket = _ITicketDAO.GetTicketWithSectionAndEvent(Id).ToDto();
            if (ticket == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ticket);
            }

        }

        [HttpGet("TicketsFromOrder/{id}")]
        public ActionResult<Ticket> TicketWithSectionAndEvent(int Id)
        {
            Ticket ticket = _ITicketDAO.TicketWithSectionAndEvent(Id);
            if (ticket == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ticket);
            }

        }



        // POST api/<TicketController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TicketController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return BadRequest("ID mismatch");
            }

            var existingTicket = _ticketDAO.GetById(id);
            if (existingTicket == null)
            {
                return NotFound();
            }

            _ticketDAO.Update(ticket);
            return Ok();
        }


        // DELETE api/<TicketController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
