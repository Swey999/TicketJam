using Microsoft.AspNetCore.Mvc;
using TicketJam.DAL.DAO;
using TicketJam.DAL.Model;
using TicketJam.WebAPI.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TicketJam.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenueControllerAPI : ControllerBase
    {
        public IDAO<Venue> _venueDAO;
        // GET: api/<VenueControllerAPI>
        [HttpGet]
        public ActionResult<IEnumerable<Venue>> Get()
        {
            return Ok(_venueDAO.Read());
        }

        // GET api/<VenueControllerAPI>/5
        [HttpGet("{id}")]
        public ActionResult<Venue> GetById(int id)
        {
            Venue venue = _venueDAO.GetById(id);
            if (venue == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(venue);
            }
        }

        // POST api/<VenueControllerAPI>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<VenueControllerAPI>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<VenueControllerAPI>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


    }
}
