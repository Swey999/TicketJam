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
            //skal ændres til returne int
            _eventDAO.InsertEvent(Event);

            //skal returnere int id og eventet når insertEvent er fixed
            return Created();
        }

    }
}
