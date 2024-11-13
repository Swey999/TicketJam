﻿using Microsoft.AspNetCore.Mvc;
using TicketJam.DAL.DAO;
using TicketJam.DAL.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TicketJam.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionControllerAPI : ControllerBase
    {
        public IDAO<Section> _sectionDAO;

        // GET: api/<SectionControllerAPI>
        [HttpGet]
        public ActionResult<IEnumerable<Section>> Get()
        {
            return Ok(_sectionDAO.Read());
        }

        // GET api/<SectionControllerAPI>/5
        [HttpGet("{id}")]
        public ActionResult<Section> GetById(int id)
        {
            Section section = _sectionDAO.GetById(id);
            if (section == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(section);
            }
        }

        // POST api/<SectionControllerAPI>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SectionControllerAPI>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SectionControllerAPI>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
