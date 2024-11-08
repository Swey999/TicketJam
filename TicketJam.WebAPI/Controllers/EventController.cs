using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketJam.DAL.DAO;
using TicketJam.DAL.Model;

namespace TicketJam.WebAPI.Controllers
{
    public class EventController : Controller
    {
        private IEventDAO _eventDAO;
        

        public EventController()
        {
            _eventDAO = new EventDAO();
        }

        // GET api/<EventControllerAPI>/5
        [HttpGet("{id}")]
        public ActionResult<Event> GetById(int id)
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
        public ActionResult<Event> AddEvent (Event Event)
        {
            int id = _eventDAO.InsertEvent(Event);
            //returns 201 + account JSON as body
            return Created($"/{Event.Id}", Event);
        }

    }
}
