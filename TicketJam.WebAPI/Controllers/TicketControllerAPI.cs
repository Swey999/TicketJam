using Microsoft.AspNetCore.Mvc;
using TicketJam.DAL.DAO;
using TicketJam.DAL.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TicketJam.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TicketControllerAPI : ControllerBase
    {

        public IDAO<Ticket> _ticketDAO;

        public TicketControllerAPI(IDAO<Ticket> iDAO)
        {
            this._ticketDAO = iDAO;
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

        // POST api/<TicketController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TicketController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TicketController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
