using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketJam.DAL.DAO;
using TicketJam.DAL.Model;
using TicketJam.WebAPI.DTOs;
using TicketJam.WebAPI.DTOs.Converters;

namespace TicketJam.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EventControllerAPI : Controller
    {
        private readonly IEventDAO _eventDAO;
        private readonly IDAO<Event> _iDAO;


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
            return Ok(eventObject);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Event>> GetAll()
        {
            return Ok(_iDAO.Read());
        }

    }
}
