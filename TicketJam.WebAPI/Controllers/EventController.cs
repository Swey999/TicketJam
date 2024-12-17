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
    public class EventController : Controller
    {
        private readonly IEventDAO _eventDAO;
        private readonly IDAO<Event> _iDAO;
        private readonly ITicketDAO _ticketDAO;

        public EventController(IEventDAO eventDAO, IDAO<Event> iDAO, ITicketDAO ticketDAO)
        {
            _eventDAO = eventDAO;
            _iDAO = iDAO;
            _ticketDAO = ticketDAO;
        }


        /// <summary>
        /// Retrives event using ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

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

        /// <summary>
        /// Adds event to database
        /// </summary>
        /// <param name="eventObject"></param>
        /// <returns></returns>

        [HttpPost]
        public ActionResult<Event> AddEvent (EventDtoForeignKeys eventObject)
        {
            //TODO: Implement transaction
            int id = _eventDAO.InsertEvent(eventObject.FromDto(), eventObject.OrganizerId, eventObject.VenueId);
            //TODO: Fix so ticket is called from TicketController
            foreach (TicketDtoForeignKeys item in eventObject.ticketDtosList)
            {
                _ticketDAO.InsertTicketWithEventId(id, item.FromDto()); 
            }
            return Ok(eventObject);
        }

        /// <summary>
        /// Gets all events to display
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public ActionResult<IEnumerable<EventDto>> GetAll()
        {
            var events = _iDAO.Read().ToDtos();// Ensure this includes Venue via eager loading.
            return Ok(events);
        }


    }
}
