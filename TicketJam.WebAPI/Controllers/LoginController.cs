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

        /// <summary>
        /// Checks if email and password matches an organizer in database, if not reponds with unauthorized
        /// </summary>
        /// <param name="organizerDto"></param>
        /// <returns></returns>

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
