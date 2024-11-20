using Microsoft.AspNetCore.Mvc;
using TicketJam.DAL.DAO;
using TicketJam.DAL.Model;
using TicketJam.WebAPI.DTOs;
using TicketJam.WebAPI.DTOs.Converters;

namespace TicketJam.WebAPI.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrganizerControllerAPI : Controller
    {
        private readonly IOrganizerDAO _organizerDAO;

        public OrganizerControllerAPI(IOrganizerDAO organizerDAO)
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
