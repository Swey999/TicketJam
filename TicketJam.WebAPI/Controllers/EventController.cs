using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketJam.DAL.DAO;
using TicketJam.DAL.Model;

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
        public ActionResult<Event> AddEvent (Event eventObject)
        {
            int id = _eventDAO.InsertEvent(eventObject);
            //returns 201 + account JSON as body
            return Created($"/{eventObject.Id}", eventObject);
        }

    }
}
