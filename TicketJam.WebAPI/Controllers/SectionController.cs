using Microsoft.AspNetCore.Mvc;
using TicketJam.DAL.DAO;
using TicketJam.DAL.Model;
using TicketJam.WebAPI.DTOs;
using TicketJam.WebAPI.DTOs.Converters;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TicketJam.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        public IDAO<Section> _sectionDAO;
        public ISectionDAO _sectionDAO2;

        public SectionController(IDAO<Section> iDAO, ISectionDAO sectionDAO)
        {
            this._sectionDAO = iDAO;
            this._sectionDAO2 = sectionDAO;
        }
        // GET: api/<SectionControllerAPI>
        [HttpGet]
        public ActionResult<IEnumerable<TicketJam.WebAPI.DTOs.SectionDto>> Get()
        {
            return Ok(_sectionDAO.Read().ToDtos());
        }

        // GET api/<SectionControllerAPI>/5
        [HttpGet("{id}")]
        public ActionResult<TicketJam.WebAPI.DTOs.SectionDto> GetById(int id)
        {
            SectionDto section = _sectionDAO.GetById(id).ToDto();
            if (section == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(section);
            }
        }

        // POST api/<SectionControllerAPI>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SectionControllerAPI>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SectionControllerAPI>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        // GET: api/VenueControllerAPI/5/sections
        [HttpGet("{id}/sections")]
        public ActionResult<IEnumerable<Section>> GetSectionsByVenueId(int id)
        {
            var sections = _sectionDAO2.GetSectionsByVenue(id).ToDtos();
            if (sections == null || !sections.Any())
            {
                return NotFound($"No sections found for venue ID {id}.");
            }
            return Ok(sections);
        }
    }
}
