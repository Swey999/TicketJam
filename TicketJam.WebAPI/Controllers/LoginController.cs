using Microsoft.AspNetCore.Mvc;
using TicketJam.DAL.DAO;
using TicketJam.DAL.Model;
using TicketJam.WebAPI.DTOs;
using TicketJam.WebAPI.DTOs.Converters;

namespace TicketJam.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private IOrganizerDAO _organizerDAO;

        public LoginController(IOrganizerDAO organizerDAO)
        {
            _organizerDAO = organizerDAO;
        }

        [HttpPost]
        public ActionResult<OrganizerDto> Post([FromBody]OrganizerDto organizerDto)
        {
            Organizer organizer = _organizerDAO.Login(organizerDto.FromDto());
            if (organizer.Id == 0)
            {
                return Unauthorized();
            }
            return Ok(organizer.ToDto());
        }

    }
}
