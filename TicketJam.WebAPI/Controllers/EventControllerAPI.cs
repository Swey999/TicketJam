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

        public EventControllerAPI(IEventDAO eventDAO, IDAO<Event> iDAO)
        {
            _eventDAO = eventDAO;
            _iDAO = iDAO;
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
        public ActionResult<Event> AddEvent (EventDtoForeignKeys eventObject)
        {
            int id = _eventDAO.InsertEvent(eventObject.FromDto(), eventObject.OrganizerId, eventObject.VenueId);
            return Ok(eventObject);
            return null;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EventDto>> GetAll()
        {
            var events = _iDAO.Read().ToDtos();// Ensure this includes Venue via eager loading.
            ///var eventDtos = events.ToDtos(); // Proper conversion of Venue to VenueDto happens here.
            return Ok(events);
        }


    }
}
