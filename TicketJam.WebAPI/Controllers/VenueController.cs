using Microsoft.AspNetCore.Mvc;
using TicketJam.DAL.DAO;
using TicketJam.DAL.Model;
using TicketJam.WebAPI.DTOs;
using TicketJam.WebAPI.DTOs.Converters;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TicketJam.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenueController : ControllerBase
    {
        public IDAO<Venue> _venueDAO;
        // GET: api/<VenueControllerAPI>

        public VenueController(IDAO<Venue> venueDAO)
        {
            _venueDAO = venueDAO;
        }

        /// <summary>
        /// Gets all venues
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public ActionResult<IEnumerable<VenueDto>> Get()
        {
            return Ok(_venueDAO.Read().ToDtos());
        }

        /// <summary>
        /// Get venue with parameter id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id}")]
        public ActionResult<VenueDto> GetById(int id)
        {
            VenueDto venue = _venueDAO.GetById(id).ToDto();
            if (venue == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(venue);
            }
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }


    }
}
