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

        [HttpPost]
        public ActionResult<Event> AddEvent (Event Event)
        {
            int id = _eventDAO.InsertEvent(Event);
            //returns 201 + account JSON as body
            return Created($"/{Event.Id}", Event);
        }

    }
}
