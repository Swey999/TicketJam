using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketJam.DAL.DAO;
using TicketJam.DAL.Model;
using TicketJam.WebAPI.DTOs;

namespace TicketJam.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VenueControllerAPI : Controller
    {
        public IDAO<Venue> _VenueDAO;
 
        // GET: VenueControllerAPI
        public ActionResult<IEnumerable<Venue>> GetAll()
        {
            return Ok(_VenueDAO.Read());
        }

        // GET: VenueControllerAPI/Details/5
        public ActionResult<Venue> GetById(int id)
        {
            Venue venue = _VenueDAO.GetById(id);
            if (venue == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(venue);
            }
        }
    }
}
