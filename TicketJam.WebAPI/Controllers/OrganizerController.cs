using Microsoft.AspNetCore.Mvc;
using TicketJam.DAL.DAO;
using TicketJam.DAL.Model;
using TicketJam.WebAPI.DTOs;
using TicketJam.WebAPI.DTOs.Converters;

namespace TicketJam.WebAPI.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrganizerController : Controller
    {
        private readonly IOrganizerDAO _organizerDAO;

        public OrganizerController(IOrganizerDAO organizerDAO)
        {
            _organizerDAO = organizerDAO;
        }

        [HttpPost]
        public ActionResult<Organizer> AddOrganizer(OrganizerDto organizer)
        {
            int id = _organizerDAO.CreateOrganizerAndReturnIdentity(organizer.FromDto());
            return Ok(organizer);
        }
    }
}
